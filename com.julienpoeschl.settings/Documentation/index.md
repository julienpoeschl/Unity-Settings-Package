<<<<<<< Updated upstream
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
=======
### Usage

## Creating a setting scriptable object

1. Rightclick in your projects assets.
2. Select `Create`, then `Settings`.
3. Pick the type of setting you want to create.
4. Rename the scriptable object created and set a default value (and limitations if float, integer or string).

Now you can either add these directly to your preexisting components or write additional logic that hooks your systems and the settings together. Your systems can set new values with `SetValue`, set default value with `SetDefault` or use `Value`. There is also an event `OnValueChanged` to listen for value changes during runtime.

## Writing additional types of settings

If the provided setting types don't cover the type of data that you want to store in a setting, you can simply create this new type of setting by writing your own.

```csharp
public class YourSetting : GenericSetting<YourType>
```

Note that you might have to overwrite methods of `GenericSetting` to fit your needs.
>>>>>>> Stashed changes
