Handles all internal Character operations, everything that wants to interact with the character must communicate with this script, not any of the other scripts.


### CanCharacterMove
returns [[CharacterMovement v0.0.1#GetIfMove]] function

### ToggleCharacterMove
toggles [[CharacterMovement v0.0.1#ToggleMove]] function

### ToggleDisplayGrid

if the characters tiles are NOT engaged

[[CharacterPathfinding v0.0.1#BeginPathfinding]] is activated

if they are engaged

[[MovementDisplay v0.0.1#RemoveDisplayedTiles]] is activated

### SetPosition

engages [[CharacterMovement v0.0.1#Set Position]]

### ReturnPosition
returns [[CharacterMovement v0.0.1#Return position]]


### ActivateMovement

Returns [[CharacterPathfinding v0.0.1#BeginPathfinding]] to an internal dictionary

if that dictionary isn't null
- [[CharacterMovement v0.0.1#AutoMoveCharacter]] is activated, using the internal dictionary