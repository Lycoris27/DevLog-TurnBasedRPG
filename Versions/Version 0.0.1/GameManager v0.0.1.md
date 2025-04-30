
# SettingsController.cs
![[Versions/Version 0.0.1/SettingsController.cs]]

- List is created with 3 elements, hook up the elements described and the settings works correctly
	- Setting name
	- Slider
	- Value Text
- The sliders and toggles are then saved as PlayerPrefs. These can be called later in the scripts that require them. This is done through an event, but it requires that all updatable scripts are active to receive the event. 
- This means it would be important for scripts that are affected by settings to have an OnActivated condition to take the stats from PlayerPrefs.

# Game Persister.cs
![[GamePersister.cs]]

- Create a new list object in inspector and add the gameObject into this section and it will persist.
- Currently there is no reason to change this, but in the future if there is any reason to persist a gameObject, it could be done by adding a public function that adds new items to the list.

# SceneScripts.cs
![[SceneScripts.cs]]

- Holds 2 functions:
- Loadscene
	- takes in a string with the scenes name, then loads the scene
- EndGame
	- Calls Application.Quit(); to exit out of the game

# CharacterManager.cs
![[CharacterManager.cs]]

- Holds all character prefabs
- Determines which character can be loaded into a scene
- Other scenes will be able to engage certain players in the list, which will then cause them to be loaded in your active player camp.

# InputManager.cs
![[InputManager.cs]]


Registers all of the inputs that can occur with the game.

Primarily handles cursor movement currently through the functions 
- OnMoveStarted
- HandleMoveHold
- OnMoveCanceled

But also has other functions set up
- HandleUI - used for registering "Enter" inputs
- Backspace - used for registering "Backspace" inputs

It is possible that this script might be drastically modified in the future with more understanding of how the new unity input system works. For Example, recently it was found that the input system can be added directly to a script allowing for an object to handle its own movement, This could mean in the future objects handle their own movement and the input manager just determines whether or not something can access its movement.

For future reference, there are a few inputs that are required for the game:
- Movement of the cursor, with the cursor registering enter and backspace inputs.
- Opening and navigation of UI elements
- Navigating through cutscenes possibly, this is a stretch goal but if we're basing it off of games such as fire emblem, then it is expected that the system will work so that button inputs progress the dialogue boxes.

The main consideration for this script into the future is how the inputManager can work between scenes.