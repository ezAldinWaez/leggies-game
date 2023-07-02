# PlayerBuilder

## Why it was written

To manage the creation of players in the map; the number of the players and the prefabs to spawn.
___

## What it does

On start, it instantiates the selected players from their prefabs (it gets the selected players from PlayerPrefs). It also has an event, OnInstantiatePlayer, and other scripts can subscribe to it to affect the new player created.
___

## How to use it

Attach it to something in the map (an empty GameObject called map options?), and create the players as prefabs with whatever components you want attached them, and only the selected players will be spawned in the map.
___

***May, 2022 - initialize***
***2 Jun, 2023 - build selected players only***