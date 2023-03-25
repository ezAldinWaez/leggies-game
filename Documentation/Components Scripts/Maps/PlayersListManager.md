# PlayersListManager

## Why it was written

To manage players’ list; to make players accessible to other scripts that need to keep track of where players are and how many players there is.

Actually, it was mainly created to save the sanity of who will read the code, as its function was implemented in [[CameraFollow]] (lol).
___

## What it does

It creates a list of player’s transforms and makes it available as a public static.

It creates a List of Transforms and subscribes two functions to the event of [[PlayerBuilder]], OnInstantiatePlayer: The first adds the instantiated player’s Transform to the list. The second subscribes its removal to the instantiated player’s [[Die]]’s onDying event.
___

## How to use it

Attach it to the same thing that has [[PlayerBuilder]], preferably. Make sure it exists in each scene.
___

***18 Sept, 2022 - initialize***