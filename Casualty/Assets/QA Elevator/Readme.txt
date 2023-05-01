Hi!
Thank you for purchase!

Here's a step by step guide:

1. Drag & drop the Elevator prefab into your scene from the QA Elevator/Prefabs/ folder;

2. Copy the Elevator few times and set the "Current Floor" property to appropriate floor;

3. Type your player's tag into the "Player tag" field (it's set to "Player" by default);

4. If you need more than one elevator shafts in the scene, you have to create an empty gameobject for the each group of elevators (shaft), and put elevators inside these empty objects (parent them). You can add the ElevatorManager.cs script to these parent empty objects to be able to set a random floor at start or set the floor manually.

To learn more about other properties in the Elevator inspector, simply move your mouse cursor on property names and you will see hints.

If you want to achieve the same visuals as on screenshots and video, check the Color Space settings in Player Settings, it should be set to Linear. Also check the Render Path settings in Graphics Settings, it should be set to Deferred.
Use free Unity 'Post Processing Stack' camera effects (https://www.assetstore.unity3d.com/en/#!/content/83912) and the adjusted profile for that, which can be founded in the QA Elevator/DemoScene/ folder.

Thanks!