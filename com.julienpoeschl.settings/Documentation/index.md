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
