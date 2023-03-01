# CameraFollow

## Why it was written

Because we need the camera to follow the players, duh.
___

## What it does

Black magic.

On Awake, it uses Magical Numbers™ to set the Camera properties. On Update, it uses even greater magic to follow the players.

It uses the list of players from [[PlayerListManager]] to reach the player’s positions. Using them, Update moves in three parts: First, find the biggest x, biggest y, smallest x, and smallest y among the players’ positions. Second, using LeggiesCameraOffset from [[LeggiesLibrary]], calculate where the camera is supposed to be to show all players and slide cleanly to follow them. Third, using sorcery from Ez Aldin Waez, set the camera size as to show all players, and scale to fit them and not to take too much space.
___

## How to use it

Attach it to the main camera and set the properties: distance from big offset x is how much away from center before needing to snap, the small one is how much before needing to gradually follow, speed is the speed (wow), and center is where to center things, a bit to the down is good, like (0, -0.55).
___

***18 Sept, 2022 - initialize***
***27 Sept, 2022 - use LeggiesCameraOffset***