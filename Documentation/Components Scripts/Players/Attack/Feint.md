# Feint

## Why it was written

To implement the part of the design that says player should be able to feint. To make feint more feint-like, on random, it also plays the attack sound and shakes.
___

## What it does

It subscribes an event, EnableFeint, to [[PlayerInput]]’s OnKeyPressed; when [[InputName]].FEINT is pressed, enable the sprite renderer (without the collider), and invoke DisableFeint after feintDuration seconds.

In DisableFeint, it checks if the attack is currently on. If it’s not, it disables the feint. (If the attack is on, we don’t want to hide the sprite, dude.)

On EnableFeint, it has a 10% chance to play the sound from [[Attack]] and extend the feint by 20% of [[Attack]]’s FireDuration while also shaking just like [[Attack]].
___

## How to use it

Attach it to the same thing you attached [[Attack]] to. 

Set the feintDuration to whatever you like. (0.25 seems cute.) 

Also set the scareProbability, between 0.0 (0%) and 1.0 (100%). If you don’t want scaring, just put it 0. If you want it to scare, set if you want it to shake, and set the shake range.
___

***May, 2022 - initialize***
***22 Sep, 2022 - random audio support***
***27 Sep, 2022 - scare and shake support***