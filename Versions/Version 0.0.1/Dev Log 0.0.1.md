#DevLog
![[ProjectVersion v0.0.1.zip]]

NOTE: This dev log will be long due to documentation not existing before this time. This will exclude modifications on scripts and objects, and instead detail that which is currently in the game.

Date: 15/04/2025

## Progress Pictures

![[Pasted image 20250415151250.png]]
![[Pasted image 20250415153250.png]]


# Added
Scripts
- [[MainMenu v0.0.1|Main Menu]]
- [[GameManager v0.0.1|Game Manager]]
- [[CursorManagement v0.0.1|Cursor Manager]]
- [[GridManagement v0.0.1 |Grid Manager]]
- [[LevelManagement v0.0.1 |Level Manager]]
- [[CharacterSheet v0.0.1|CharacterSheet]]
- [[MovementDisplay v0.0.1|MovementDisplay]]
- [[CharacterPathfinding v0.0.1|CharacterPathfinding]]
- [[CharacterMovement v0.0.1|CharacterMovement]]
- [[CharacterAI v0.0.1|CharacterAI]]
- [[MovementTileScript v0.0.1|MovementTileScript]]
- [[GridTileActivator v0.0.1|GridTileActivator]]
GameObjects
- [[CharacterGameObject v0.0.1]]
- [[GridTiles]]
- 
# Changed

No updates, as this is the first Dev Log
# Challenges

1 issue
- Item & inventory systems
	- Seem to be too complicated at this stage

# Fixed

No fixes, as this is the first dev log
# Removed

1 removal
 - Item & inventory systems
	 - Until further notice


# Planned

This section will be updates as progress continues.

- Update Pathfinding system to include Environmental Context
	- **Current system:**  finds target, optimizes path, finds furthest range it can attack from. 
	- **Updates system:** scan environment for good positions, check if they are within attack range of target, attack from more advantageous position
	- **Update goal**: by next Dev Log (expectation is within a week)
- Update Level Management to be in a workable state
	- The current 


 I want to improve pathfinding for enemies as well, including being able to redirect their attacks to characters  that are within their range but have lower defensive stats, being able to find terrain locations to attack from to give them an advantage, and attacking from max range if the target cannot attack them back.

# Closing Thoughts

Game Progress is going decently well so far, the main things that need to be worked on for the game to be in a playable state is the turnscript and a combathandler, once these two can be sorted out, legitimate playtests could occur. 

If anything is missed, this [[Addendum to DevLog v0.0.1 |Addendum Devlog Page]] will be active.
