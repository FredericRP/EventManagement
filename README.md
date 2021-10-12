# Event Management

A generic event handler that allows you to subscribe and trigger game events in your game in a minute.

GameEvents have evolved thanks to the Unite 2017 presentation by Schell Games (but we still prefer our way to handle listener with delegates).

## Usage

1. Create new game events from the project view using Create / FredericRP / [...] Game Event (with a typed parameter or no parameter)

2. Use it by Code
- add a delegate that will receive the event using AddEventListener (and RemoveEventListener)
- trigger the event using TriggerEvent

3. **OR** Use it with provided *SimpleEventTrigger*
- put this MonoBehaviour on a GameObject
- assign the game event you just created
- add as many unity events as you want to call functions

See the **[Screen Transition](../ScreenTransitions) demo**.

## Advanced

If you need new typed game event, you can open the **New type game event** window under *Window / FredericRP / EventManagement / New type generation* and specify from 1 to 9 types to generate the new game event.

For instance, you can indicate 3 types as string, int and MyAssembly.MyClass and it will generate the StringIngMyAssemblyMyClassGameEvent parented to ThreeTypeGameEvent and its StringIngMyAssemblyMyClassGameEventInspector