# Die

## Why it was written

To have things die and make a sound when they do.
___

## What it does

It has a Boolean for each way to die. If set to true, it will subscribe SelfDestruct to the relevant event. It also has a Boolean for making a sound; if true, it will choose a random clip from the provided ones and play it.

However, it can’t play a sound when it is destroyed, duh. So, it creates an empty GameObject and gives it the clip to play. That object plays the clip then gets destroyed.

It also has a Setter for DelegateDeath. If sth calls it, it will not destroy the object, and it will let others deal with it. That is, it will delegate the death to them. But it will still be called dead, and it will be removed from [[PlayerListManager]]’s Players List.
___

## How to use it

Attach it to the things that should die, alongside the things that offer events of death. And give it some audio clips of death.

Also, this offers an event you can subscribe to, OnDying.
___

***May, 2022 - initialize***
***21 Sept, 2022 - audio support***
***22 Sept, 2022 - make delegating death***