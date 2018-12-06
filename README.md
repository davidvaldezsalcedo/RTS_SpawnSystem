# RTS_SpawnSystem
A procedural spawn system for Units and Buildings designed for RTS games


## How It Works

It allows for the designers to create their own RTS behavior using Unitys UI and Scriptable Objects. 
The BuildingData script contains the holder of the objects that each building will be able to spawn. In here you can add infantry units for artillery/AirFields/Infantry buildings or CommandCenters to the ObjectsInBuilding array. then you can assign Sprite images that will show in the UI for that specific Unity/Building type as well as the name of that object in 2 seperate arrays respectively.

## How To Use

**An example Scene is included in the package to show an example setup. 
**The 3D art Assets are not mine, they are not used in any commercial form

- You must create a Canvas for the UI. In the main Canvas game object place the UIHoverListener
- The UI should have an empty game object With the UIBehaviour script. This object should hold all the UI buttons under it as children. These will be added to a List.
- Create a scriptable object Bool and Camera variable in the project by right clicking and selecting Variables/bool and camera.
- Add my CameraBehavior script to your camera (its a basic demo script so you might want to create a more complex one). Then drag and drop the new camera variable into the camera slot of the component. If you are using your own camera script, create a RefCamera variable in the script and drag and drop the scriptable object camera variable into it, then add this line of code in the Awake() function ** _Camera.Value = GetComponent<Camera>();
- The scriptable object bool variable should be to check if the mouse is hovering over a UI element, so name it accordingly. Drag and drop it in the UIHoverListener script in your canvas.
- Create an empty game object for the Spawner in t he Scene.
- Add the BuildingSpawner script and the UnitySpawner script to the Spawner Game Object.
- In the BuildingSpawner script on the Spawner Game Object, drag and drip the scriptable object bool and camera variables you created, and in the Layer to Check spot select the layer for your Terrain/Ground.
- Create All of your buildings in the Scene and make them prefabs (make sure they have a collider and rigidbody in the parent object).
- Add the BuildingBehavior script to all of them.
- for any building that spawns AI units (Infantry, Artillery, etc..) tick on the SpawnUnits bool in the component. Make sure the CanSpawn bool is ticked off for all the prefabs, except for the initial buildings the player will have in the Scene at the beginning of the level.
- Add the scriptable object bool for the HoverListener in the MouseHoveringUI slot.
- Right click in the project window and go to the create/Buildings/ path and create a scriptable object BuildingType. This is how you create different types of buildings that can spawn different Units/Buildings. 
- Create as many BuildingTypes as you have buildings that can be spawned for the game.
- In this scriptable object, you can add buildings or unit game objects depending on what your building type will be spawning into the ObjectsInBuilding array. Then add the sprites the UI will be showing for each GameObject in the ImagesForObjects array. Then add the name of the object that will be shown in the UI in the TextForButtons array. All of these should be entered relative to each other.
    Example:
        ObjectsInBuilding
          Element 0 - [GameObject] AdvancedInfantry
          Element 1 - [GameObject] Artillery
        ImagesForObjects
          Element 0 - [Sprite] AdvancedInfantry
          Element 1 - [Sprite] Artillery
        TextForButtons
          Element 0 - [String] "Advanced Infantry"
          Element 1 - [String] "Artillery"
  
- Once these are created, add the scriptable object BuldingTypes you created to the respective Building prefabs in the BuildingType slot.

