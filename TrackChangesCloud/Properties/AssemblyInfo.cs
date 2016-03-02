using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle( "TrackChangesCloud" )]
[assembly: AssemblyDescription( "A C# .NET Revit add-in to track Revit BIM database modification history by creating, comparing and archiving element property snapshots in the cloud." )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "Autodesk Inc." )]
[assembly: AssemblyProduct( "TrackChangesCloud Revit Add-In" )]
[assembly: AssemblyCopyright( "Copyright 2016 © Jeremy Tammik Autodesk Inc." )]
[assembly: AssemblyTrademark( "" )]
[assembly: AssemblyCulture( "" )]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible( false )]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid( "321044f7-b0b2-4b1c-af18-e71a19252be0" )]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
//
// TrackChanges History:
//
// 2016.0.0.0 2016-01-20 initial version
// 2016.0.0.1 2016-01-21 fixed added deleted mixup in report, added start and stop notification
// 2016.0.0.2 2016-02-02 Jason Schaeffer @joespiff added a null check to avoid issues with rooms having null geometry
// 2016.0.0.3 2016-03-02 final clean-up before splitting off TrackChangesCloud
//
// TrackChangesCloud History:
//
// 2016.0.0.4 2016-03-02 copied TrackChanges history and incremented version number
//
[assembly: AssemblyVersion( "2016.0.0.4" )]
[assembly: AssemblyFileVersion( "2016.0.0.4" )]
