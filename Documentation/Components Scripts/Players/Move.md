# Move

## Why it was written

To implement the part of the design that says the player should move. 😊
___

## What it does

It subscribes an anonymous function to [[PlayerInput]]: whenever a key is pressed, it checks if it is relevant ([[InputName]].UP, DOWN, LEFT, RIGHT), and it adds a force to the script owner accordingly. Therefore, for each time the key is pressed, more force is added (it won’t continue moving if you hold the key).
___

## How to use it

Attach the script to what you wish to be moved according to input.

Specify the power of the force added from a single key press. (300 seems to be a good choice.)

The script itself does not move the object, so you need a [[PlayerInput]] script attached as well.
___

***May, 2022 - initialize***