#region Namespaces
using System;
using System.Diagnostics;
using Autodesk.Revit.UI;
#endregion

namespace TrackChangesCloud
{
  class ModificationLogger : IExternalEventHandler
  {
    /// <summary>
    /// Required IExternalEventHandler interface 
    /// method returning a descriptive name.
    /// </summary>
    public string GetName()
    {
      return "TrackChangesCloud ModificationLogger";
    }

    /// <summary>
    /// Execute method invoked by Revit via the 
    /// external event as a reaction to a call 
    /// to its Raise method.
    /// </summary>
    public void Execute( UIApplication a )
    {
      Util.Log( "ModificationLogger.Execute" );
    }
  }
}
