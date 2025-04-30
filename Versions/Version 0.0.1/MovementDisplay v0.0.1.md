![[MovementDisplay.cs]]


### DisplayPredictionTiles

takes in Dictionary(Vector2Int, int)

- Foreach item in the dictionary
	- Activates the movetile at the location
- Adds the taken in dictionary to moveGrid in case the area needs to be removed

### DisplayAttackTiles

takes in dictionary(Vector2Int, int)

- Foreach item in dictionary
	- Activates attacktile at the location
- Adds the taken in dictionary to attackGrid in case the area needs to be removed

### RemoveDisplayedTiles

takes all inputs from moveGrid and attackGrid

- foreach input in these
	- Grabs the associated GridTileActivator script and deactivates it
- Nulls both attackGrid and moveGrid at the end

