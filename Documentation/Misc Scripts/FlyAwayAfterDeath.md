# Die

## Why it was written

To improve the chaos of the game, to make things go woosh when killed.
___

## What it does

It subscribes a function to [[Die]]’s OnDying and Delegates the Death to it.

It adds great force in a random direction then destroys the object after one second.
___

## How to use it

Attach it to what you want fly like that when killed and specify the fly power.

This requires the object to have a Rigidbody2D. If you added it to sth that does not have it, and you don’t want it to actually have a Rigidbody2D, just choose static for its body type; the script will do its work.
___

***22 Sept, 2022 - initialize***