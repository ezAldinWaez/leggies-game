# Retreat

## Why it was written

To implement the part of the design that says the player should dash with cute sounds (well, it became retreat when we programmed it). 😊
___

## What it does

It subscribes an anonymous function to [[PlayerInput]]: whenever a key is pressed, it checks if it is the relevant key ([[InputName]].RETREAT), and it adds a force to the opposite direction of the current velocity. 

It has a Boolean for audio; if true, it will choose a random clip from the provided ones to play.
___

## How to use it

Attach it to the player and specify the retreat force (1000 seems to be good). And give some audio clips to use as retreating sound effects.

The script itself does not move the object, so you need a [[PlayerInput]] script attached as well.
___

***May, 2022 - initialize***
***21 Sep, 2022 - audio support***