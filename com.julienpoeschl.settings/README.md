# How to use
## Create new settings
To make new settings, navigate to your assets, press left-click, `Create` and search for `Settings`. There you can select one of the generic settings types:
- bool
- integer
- float
- string
- binding
to create a scriptable object instance of that setting. This object will hold the data related to the setting and is accessable from every game scene and keeps state after loading a new scene.

## Introducing new types of settings
If you want to add settings of different types, you can write your own setting scriptable object, inheriting from `GenericSetting`. This can then be accessed as the other settings, but will use your defined data.

