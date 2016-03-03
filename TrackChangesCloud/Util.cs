#region Namespaces
using System;
using System.Diagnostics;
#endregion // Namespaces

namespace TrackChangesCloud
{
  class Util
  {
    /// <summary>
    /// Print a debug log message with a time stamp
    /// to the Visual Studio debug output window.
    /// </summary>
    public static void Log( string msg )
    {
      string timestamp = DateTime.Now.ToString(
        "HH:mm:ss.fff" );

      Debug.Print( "TrackChanges " 
        + timestamp + " " + msg );
    }
  }
}
