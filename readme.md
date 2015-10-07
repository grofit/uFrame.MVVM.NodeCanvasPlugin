# NodeCanvas Generator for uFrame MVVM

This plugin adds codegen templates to generate NodeCanvas actions and conditions based upon your view model properties and commands.

The actions are automatically created when you save and compile your graphs so they will automatically stay in sync with your view models. If you are interested you can see the raw designer output actions within `NodeCanvasActions.designer.cs` which will be output to where the rest of the uFrame codegen designer files live.

# Installation

- Install NodeCanvas 2.*
- Install uFrame MVVM 1.6.*
- Install this plugin

That should hopefully be enough to get you going, if for some reason the plugin does not self register you will need to go to `uFrame > Settings` in the unity menu and make sure the `NodeCanvasGenerator` plugin is ticked.

You can install this via the unity package in the `Dist` folder on github, or you can clone this project and take just the files you want.

# Develop

If you want to develop this library further then you will need to clone this library, install NodeCanvas and uFrame MVVM.

# Examples

The example scene is part of this project and not put into the `unitypackage` file, so if you want to test that then follow the develop instructions above, then run the scene in the Example folder. This will have a View with a BehaviourTree assigned which will show some of the example actions.

Here is what it looks like incase you don't want to load it up to see it.

![2015-10-07_13-11-38](https://cloud.githubusercontent.com/assets/927201/10337072/40a66eb6-6cf5-11e5-8c25-73461b9a1948.jpg)