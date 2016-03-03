#region Namespaces
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System.Diagnostics;
using Autodesk.Windows;
#endregion

namespace TrackChangesCloud
{
  class App : IExternalApplication
  {
    /// <summary>
    /// Store the external event.
    /// </summary>
    static ExternalEvent _event = null;

    /// <summary>
    /// Separate thread running a timer to trigger
    /// the modification tracker at regular intervals.
    /// </summary>
    static Thread _thread = null;

    /// <summary>
    /// Count total number of modification tracker
    /// snapshots taken so far in this session.
    /// </summary>
    static int _nSnapshots = 0;

    static int _timeout_minutes = 1;

    /// <summary>
    /// Number of milliseconds to wait and relinquish
    /// CPU control before next snapshot.
    /// </summary>
    static int _timeout = 1000 * 60 * _timeout_minutes;

    #region SetFocusToRevit
    // DLL imports from user32.dll to set focus to
    // Revit to force it to forward the external event
    // Raise to actually call the external event 
    // Execute.

    /// <summary>
    /// The GetForegroundWindow function returns a 
    /// handle to the foreground window.
    /// </summary>
    [DllImport( "user32.dll" )]
    static extern IntPtr GetForegroundWindow();

    /// <summary>
    /// Move the window associated with the passed 
    /// handle to the front.
    /// </summary>
    [DllImport( "user32.dll" )]
    static extern bool SetForegroundWindow(
      IntPtr hWnd );

    static void SetFocusToRevit()
    {
      IntPtr hRevit = ComponentManager.ApplicationWindow;
      IntPtr hBefore = GetForegroundWindow();

      if( hBefore != hRevit )
      {
        SetForegroundWindow( hRevit );
        SetForegroundWindow( hBefore );
      }
    }
    #endregion // SetFocusToRevit

    /// <summary>
    /// Repeatedly check database status and raise 
    /// external event when updates are pending.
    /// Relinquish control and wait for timeout
    /// period between each attempt. Run in a 
    /// separate thread.
    /// </summary>
    static void TriggerModificationLogger()
    {
      while( true )
      {
        ++_nSnapshots;

        Util.Log( string.Format( 
          "TriggerModificationLogger snapshot {0}", 
          _nSnapshots ) );

        _event.Raise();

        // Set focus to Revit for a moment.
        // Otherwise, it may take a while before 
        // Revit forwards the event Raise to the
        // event handler Execute method.

        SetFocusToRevit();

        // Wait and relinquish control 
        // before next snapshot.

        Thread.Sleep( _timeout );
      }
    }

    public Result OnStartup( UIControlledApplication a )
    {
      a.ControlledApplication.ApplicationInitialized 
        += OnApplicationInitialized;

      return Result.Succeeded;
    }

    void OnApplicationInitialized( 
      object sender, 
      ApplicationInitializedEventArgs e )
    {
      _event = ExternalEvent.Create( 
        new ModificationLogger() );

        _thread = new Thread(
          TriggerModificationLogger );

        _thread.Start();

    }

    public Result OnShutdown( UIControlledApplication a )
    {
      _thread.Abort();
      _thread = null;
      _event.Dispose();

      return Result.Succeeded;
    }
  }
}
