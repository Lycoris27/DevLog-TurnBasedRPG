
### Return position
returns the characters position

### Set Position
allows the position to be set outside of itself, mostly handled inside itself however


### GetIfMove
returns canCharacterMove

### ToggleMove
toggles canCharacterMove

### AutoMoveCharacter
takes in a dictionary(Vector2Int, int)

Finds the characters movement and range from the [[CharacterSheet v0.0.1|CharacterSheet]] then checks the dictionary to see if it is greater than the range and movement combined.
- if it is, check all values in the dictionary
	- if one is equal to moveLocations.Count - range
		- Set that to be the position
- If it isn't, check if dictionary count is lesser than movement + range
	- if dictionary has a value equal to movement
		- move there