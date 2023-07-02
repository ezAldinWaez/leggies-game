# TimeoutDieCause

## Why it was written

To allow things to die after a specified amount of time. Made originally for throwables to disappear.
___

## What it does

It implements [[DieCause]], isDieCauseLethal returns true when time has exceeded the timeoutTime (a SerializeField). It calls OnDetectedDieCause on Update.
___

## How to use it

Attach to what would die by timeout, assign a value to timeoutTime. Also attach a [[DieMethod]] and link with this. 
___

***25 Mar, 2023 - initialize***