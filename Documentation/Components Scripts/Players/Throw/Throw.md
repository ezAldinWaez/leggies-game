# Throw

## Why it was written

To implement the part of the design that says players can throw attacks.
___

## What it does

When the throw key is pressed, it instantiates an object with the [[Throwable]] script and applies force in a random direction. It also implements a cooldown period before enabling throwing again.
___

## How to use it

Attach it to the player and fill out the properties: cooldown period, what object to throw (it must have the [[Throwable]] script in it), how much the throwable will shake, what it will sound, and the force applied.
___

***2 Jul, 2023 - initialize***