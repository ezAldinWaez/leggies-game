# Attack

## Why it was written

To implement the part of the design that says that players attack with a sound effect and shaky effects.
___

## What it does

It subscribes a method, EnableAttack, to [[PlayerInput]]’s event, OnKeyPressed. When [[InputName]].ATTACK is pressed, it will enable the attack (its sprite renderer and polygon collider), then invoke DisableFire after fireDuration (private property) seconds.

DisableFire will disable the sprite renderer and the collider, and set the player’s color to the cooldownColor (another private property), then Invoke SetColorWhite after cooldownDuration (yet another private property) seconds.

As for audio, it has three clips: one at the beginning, one to be looped, and one for the end. 
Along all that chaos, EnableAttack will also call StartAttackSound that plays the start sound, and it Invokes another function to loop. And DisableAttack calls StopAttackSound, which plays the stop sound.

The attack’s size scales down through the attack, shaking in the process through calling [[LeggiesLibrary]]’s LeggiesMath’s ShakeVector3. It only does that if you set willShake to true.
___

## How to use it

Attach it to the first child of the player, the attack. Set the properties (fireDuration, cooldownDuration, and cooldownColor) however you like. (Maybe try 5 for fireDuration, 7 for cooldownDuration, and some faint red color for cooldownColor.)

Also specify the sounds it plays. If you have one thing only to loop (instead of a thing that has a start part, a loop part, and an end part), then you can put it as both start and loop and keep end null.

As for shaking, set willShake true if you want shaking effects, and give the range of shaking.
___

***May, 2022 - initialize***
***21 Sept, 2022 - audio support***
***27 Sept, 2022 - shake support***