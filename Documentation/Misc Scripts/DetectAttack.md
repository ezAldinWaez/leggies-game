# DetectAttack

## Why it was written

To detect an attack and let other scripts process the info.
___

## What it does

It has a public method, OnDetectedAttack, that [[DetectAttackables]] calls when it discovers it.

It also has a private method, IsAttackLethal, that checks if the attack will kill this object. It compares the time-since-last-fire and does stuff.
___

## How to use it

Attach it to whatever you want detect attacks. 

This script has an event that you can subscribe to, providing the lethality of the attack. Subscribe the methods that deal with attack.
___

***May, 2022 - initialize***