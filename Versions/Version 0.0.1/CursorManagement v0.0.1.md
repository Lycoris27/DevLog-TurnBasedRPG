

Scripts involved with CursorManagement

# CursorMove.cs
![[CursorMove.cs]]

How script works:
- Takes in variable CursorPos to determine position.
- Uses function SetPosition to set its position.
- Uses OnValidate to change position in inspector
- Moves through Move function, which takes in WASD movement value to set the next position it will be at, then calls SetPosition to confirm posititon change.
- Calls cursorDetect script to detect if there is a player



# CursorDetect.cs
![[CursorDetect.cs]]

Primary functions: (functions names are subject to change due to being used for player and enemy characters)
- DetectPlayer
- ProgressPlayerMovement
- RegressPlayerMovement

DetectPlayer
- Checks the tilespace under the cursor.
- if Character is found, holds the gameObject and its CharacterAI script to communicate with it.
	- if player found, sets foundplayer to true
	- if enemy found, sets foundenemy to true
- If no character found, sets foundplayer and foundenemy to false
	- if player is not moving, nulls heldcharacter and characterAI as it doesn't need to communicate with them.

ProgressPlayerMovement
- Has 4 checks
- if foundenemy is true and player isn't moving, toggles the enemies display grid.
- if foundplayer is true, player isn't moving, and character can move
	- holds the cursorposition for later
	- sets playermoving and onmovetile to true
	- toggles the players display grid
- if player is moving and they are on a movetile through onmovetile = true
	-  Moves the character to new position
	- changes where the player is stored in the gridDetector ==(this might need to be moved into characterMovement so that enemies can access it)==
	- sets finalcheck to true
- if finalcheck is true
	- Sets playerMoving, finalcheck, onmovetile to false
	- sets foundplayer to true
	- sets heldposition to 0,0
	- Toggles the characters displaygrid and characterMove so the character can't move and doesn't show its movement.
	- sends a ping to the levelmanager to see if the turn should change to enemy turn.

RegressPlayerMovement
- Has 2 checks
- if playermoving is true
	- set it and onmovetile to false
	- toggle the displaygrid (sets it to off)
	- sets heldposition to (-1,-1)
- if finalcheck is true
	- sets finalcheck to false
	- resets character position to its old position
	- resets character position in griddetector to old position