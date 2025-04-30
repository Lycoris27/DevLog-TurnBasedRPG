
Handles the **GridDetector** and **Turnscript**

# GridDetector.cs
![[GridDetector.cs]]

Sets the grid depth and width through similar named variables
holds a dictionary of gameObjects

Finds the grid for the scene:
- sets all players enemeis and tiles into their own array
- Foreaches all objects in each list
- if certain conditions are met, then adds their position into the gridDetectedObjects dictionary.


### GridDetectedObjects
Dictionary<Vector2Int, ListGameObject>();

Vector2Int - Sets based on position

List GameObject () has 3 sections:
- 0 all tiles get set here
- 1 all characters get set here
- 2 all movement tiles get set here, not handled in this script.


### ReturnTileData
- Returns all tiledata after being given a position

### ReturnGridSize
- Gives the GridDepth and GridWidth as a Vector2Int

### SetTileData
- Allows for the modification of tiledata based on position, index and object
	- Position - finds specific location in dictionary
	- Index - finds specific position in dictionary list, either 0, 1 or 2
	- obj - what the position at 0,1 or 2 should be replaced with


# TurnScript

![[TurnScript.cs]]

Holds all players in variable Lists Player and Enemies


### FindUnits
- finds objects with tags player and enemy and adds them to Players and Enemies respectively

### CheckIfTurnChange

- If its the players turn, #CheckPlayersInactive to see if they are inactive
	- if they are, #SetAllPlayersActive for enemies, turns off players turn, and runs enemyAI
- if not
	- #SetAllPlayersActive to true
	- playersturn is set to true

### CheckPlayersInactive

- Foreach player in players
	- checks if they can move if they can
		- returns false, as not all players are inavtive yet
- if it runs through all of them and finds that all are inactive
	- returns true, as all players are inactive


### SetAllPlayersActive

- Foreaches all characters in character list
	- Grabs their #characterAI
	- if their movement type is set to the opposite of what they want
		- toggles their movement
- Invokes #OnPlayersTurnStart 

### RunEnemyAI
- #EngageEnemyTurn if it isn't players turn

### EngageEnemyTurn

- Foreaches all enemies in enemyList
- Activates their movement
- #Checkifturnchange