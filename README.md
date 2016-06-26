# TrackChangesCloud

A C# .NET Revit add-in to track Revit BIM database modification history by creating, comparing and archiving element property snapshots in the cloud.

This project is a continuation and enhancement of the initial non-cloud-based external command Revit
add-in [TrackChanges](https://github.com/jeremytammik/TrackChanges).

For more information, please refer
to [The Building Coder](http://thebuildingcoder.typepad.com) and
the detailed article about the initial TrackChanges implementation
for [tracking element modification](http://thebuildingcoder.typepad.com/blog/2016/01/tracking-element-modification.html).


## Enhancement &ndash; Automatic Snapshots and Cloud Storage

This project implements
the [TrackChanges enhancement suggestion](https://github.com/jeremytammik/TrackChanges#enhancement)
and makes use of the cloud storage approach developed for
the [FireRatingCloud](https://github.com/jeremytammik/FireRatingCloud) project to do so.


## Further Enhancement Possible

Tim Cornelissen [reports](http://forums.autodesk.com/t5/revit-api/dynamic-model-update-after-loading-family/m-p/6402184#M16891) that
the current solution works really well but cannot be implemented in a real-time solution in its current state.
It takes just a few seconds to collect all specified data in bigger project and interrupts designers too often when called on each addition and modification.

Jeremy suggests:

- Use the DMU in conjunction with a timer. Make a note of the added, deleted and modified element ids, but do not process them unless a certain amount of time has passed.
- Use the DMU to capture the list of s, but do nothing else with them. Enhance the regular timer-based TrackChanges snapshot to process only the listed elements instead of the entire database. Run the TrackChanges snapshot as often as needed, but not more, e.g. only once a minute.


## Author

Jeremy Tammik,
[The Building Coder](http://thebuildingcoder.typepad.com) and
[The 3D Web Coder](http://the3dwebcoder.typepad.com),
[Forge](http://forge.autodesk.com) [Platform](https://developer.autodesk.com) Development,
[ADN](http://www.autodesk.com/adn)
[Open](http://www.autodesk.com/adnopen),
[Autodesk Inc.](http://www.autodesk.com)


## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT).
Please see the [LICENSE](LICENSE) file for full details.
