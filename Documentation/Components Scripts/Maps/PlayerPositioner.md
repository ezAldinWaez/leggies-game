# PlayerPositioner

## Why it was written

To set the initial position of the players.
___

## What it does

It has a List of Vector3, representing the initial position of each player.

It subscribes a method, SetPlayerPosition, to the event of [[PlayerBuilder]], OnInstantiatePlayer. That method sets the position of the new player accordingly.

However, if the new player has no entry in the List of initial positions, it sets the initial position to (0, 0, 0).
___

## How to use it

Attach it to the same thing that has [[PlayerBuilder]], and set the initial positions.
___

***May, 2022 - initialize***