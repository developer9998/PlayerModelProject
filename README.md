# GorillaPlayerModelModProject-Master
Unity project version 2019.3.15 with scripts allowing you to create Playermodel files (*.gtmodel)

Use the .blend file in the assets folder for the rig (made for the playermodel mod) 
Will change in the future, in the .blend file KEEP the transforms to 0.01 for scaling

![image](https://user-images.githubusercontent.com/65086429/172030977-3c47a981-4416-465b-9d55-75e243fa4e16.png)

- Player Model Name : Name your model
- Author : Put your name here
- Lefhand : left hand bone
- Righthand : right hand bone
- Torso : the toro/hips of the rig
- Body : The mesh of the model
- Custom Color : Enables custom colors on your playermodel
- Game Mode Textures : Enables Game Mode Textures on your playermodel

Create an Empty GameObject and reset the transforms, attach the PlayermodelDescriptor to it.
Import your model with the rig from the .blend file, and attach it to the GameObject.
Apply your materials to the model
Assign the specified bones to the PlayermodelDescriptor

To test the playermodel in the editor,
Enable the OfflineRig_GorillaPlayer
Press play in the editor.
If the Playermodel was setup correctly, your playermodel should be copying the pose of the OfflineRig_GorillaPlayer
Also, green shapes should apear on your playermodel arms.
Press play again to exit.

Last is to export the .gtmodel file

Go the Menu item "Assets"
Then "Create Player Model"

The Console will print the name of your player model.
The playermodel is exported to the PlayerModelOutput Folder

Drap the .gtmodel file into the PlayerAssets folder in the PlayerModels Mod folder

D O N E

Using fast ik script from https://github.com/ditzel/SimpleIK
