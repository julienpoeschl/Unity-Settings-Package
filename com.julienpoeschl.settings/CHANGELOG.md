### Releases

## v1.0.0 (07.02.2026)

Initial release of unity package.

# Features

- Abstract generic setting scriptable object base class `GenericSetting`. Every setting extends from this class. New settings can be written by extending from this as well.
- `FloatSetting`, `StringSetting`, `IntegerSetting`, `BoolSetting` fully implemented, handling the given types of settings.
- Custom editor scripts `FloatSettingEditor`, `StringSettingEditor`, `IntegerSettingEditor` and `BoolSettingEditor`, handling the allowed values for `defaultValue` and providing a readonly field of `currentValue` and a button to set it to the default value.

## v1.0.1 (11.02.2026)

Minor change to `SetValue` method.

# Changes
- Instead of returning in case of invalid new values, the `SetValue` method now throws an `ArgumentException` (`ArgumentNullException` or `ArgumentOutOfRangeException`).


## v1.0.2 (12.02.2026)

Minor changes to setting hierarchy.

# Changes
- Addition of non-generic base class `Setting`
- Addition of new `GenericNumericSetting`, grouping `IntegerSetting` and `FloatSetting` together, providing a `FloatValue` and `Range` property.
