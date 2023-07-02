# DieCause

## Why it was written

Because there might be new causes to die, so instead of editing die, you can just create a class that inherits from this. Like, written to make code cleaner and to collect the code in common between all causes.
___

## What it does

It has an abstract bool method, isDieCauseLethal, where you'd implement the logic of the new cause.  And OnDetectedDieCause, which checks if lethal then invokes the DieMethod associated with it. You have to implement when to call OnDetectedDieCause as well.
___

## How to use it

Just write classes that inherit from it. No other use.
___

***25 Mar, 2023 - initialize***