# Event management Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).
For 1.2.2 release and previous ones, this is a copy/paste from FredericRP's Standard Assets changelog, filtered for this sub package (that's why some version have no content here).

## Unreleased

## [1.5.3] - 2022-04-06

### Fixed
- Override references in asmdef to lower reload times
- Auto dependencies in package

## [1.5.2] - 2021-12-23

### Fixed
- GameEventHandler was meant to be a simple class, not a MonoBehavior, this is now fixed

### Changed
- Protection against setting a value with a null GenericReference

## [1.5.1] - 2021-12-08

### Fixed
- ThreeTypeGameEvent Singleton usage

## [1.5.0] - 2021-12-08

### Changed
- allow multiple event handlers: GameEventHandler is now a autonomous class, Singleton is held in GameEventHandlerSingleton behaviour

## [1.4.0] - 2021-10-12

### Added
- EditorWindow to create new typed game events as they only rely on their generic parent class but Unity can not handle inspector window and serialization on generic only. Use carefuly as its a basic code generation.
- Ability to listen and delete event listener from generic events
- GenericValue to allow choosing between a value serialized in the game event or a referenced value for designers

### Changed
- Generic inspector and events to be able to easily add new typed game events and their inspector
- Renamed SimpleEventTrigger to CallUnityActionOnEvent for better understanding
- FloatGameEvent has now its own Raise method with a float parameter
- SimpleEventTrigger use the new way of calling event Raise method instead of GameEventHandler methods

## [1.3.0] - 2021-09-15

### Changed
- Use its own repository
- Do not use GUIDs for assembly references to make it clearer if an assembly is not found
- Added virtual to GameEvent methods to allow override

### Fixed
- Do not throw a null pointer when exiting play mode when removing event listener
- Added namespace for value reference children classes

## [1.2.2] - 2021-07-30

### Added
- NEW: supporting two and three arguments for event handling
- NEW: ability to use either a global GameEventHandler or multiple ones

### Changed
- MOD: EventHandler class has been renamed to GameEventHandler to prevent issues when you want to import System
**Breaking change**: use only GameEvent (Raise, Listen, Delete) methods instead of EventHandler (Trigger, Add, Remove), that was always meant to be that way.

### Fixed
- FIX: Editor platform only for editor assemblies on asset bundle tool, event management and object pool

## [1.2.1] - 2020-07-30

### Added
- NEW: Generic, Float and Int reference value (scriptableobject)
- NEW: Installation guidelines for both package and submodule.

### Changed
- MOD: make package manager compatible

### Fixed
- FIX: changelog meta files
- FIX: warning log when using incorrect delegate on event handler
- FIX: Int Float game event inspector did not allow to change value
- FIX: correct MIT license for every package
- FIX: readme file with updated Documentation folder

## [1.2.0] - 2019-11-19

### Changed
- MOD: updated readme files for each plugin
- MOD: updated readme file for full instructions

## [1.1.0] - 2019-10-27

### Added
- NEW: typed game event with int and float parameters

### Fixed
- FIX: remove event listener on disable simple event listener

## [1.0.1] - 2019-10-16

### Added
- NEW: github social preview

### Changed
- MOD: all previous readme.txt changed to markdown format

### Removed
- DEL: removed first package export

## [1.0.0] - 2019-08-08

### Added
- first public release: a generic event handler to trigger and subscribe game events in your game in a minute.

### Changed

### Deprecated

### Removed

### Fixed

### Security
