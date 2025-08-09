using Persistency;
using UnityEngine;

namespace Settings
{
    public class SettingsManager : MonoBehaviour, IPersistentSettings
    {
        // Singleton
        public static SettingsManager Instance { get; private set; }

        public static IPersistentSettings PersistenSettingsInstance { get; private set; }

        [Header("Display Settings")]
        [SerializeField] private IntegerSetting fov;
        [SerializeField] private BoolSetting fullscreen;

        [Header("Audio Settings")]
        [SerializeField] private FloatSetting masterVolume;
        [SerializeField] private FloatSetting musicVolume;
        [SerializeField] private FloatSetting sfxVolume;
        [SerializeField] private FloatSetting uiVolume;

        [Header("Controls Settings")]
        [SerializeField] private BoolSetting xInverted;
        [SerializeField] private BoolSetting yInverted;
        [SerializeField] private IntegerSetting xsensitivity;
        [SerializeField] private IntegerSetting ysensitivity;


        [Header("Accessibility Settings")]

        [Header("Debugging")]
        [SerializeField] private bool notifyReset;
        [SerializeField] private bool notifyPersistency;

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            PersistenSettingsInstance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void ResetAllSettings()
        {
            ResetDisplaySettings();
            ResetAudioSettings();
            ResetControlsSettings();
            if (notifyReset) Debug.Log("Resetting all settings.");
        }

        public void LoadSettings(PersistentSettings settings)
        {
            LoadDisplaySettings(settings.Display, settings.DisplayInitialized);

            LoadAudioSettings(settings.Audio, settings.AudioInitialized);

            LoadControlsSettings(settings.Controls, settings.ControlsInitialized);
        }

        public void SaveSettings(ref PersistentSettings settings)
        {
            SaveDisplaySettings(ref settings.Display);

            SaveAudioSettings(ref settings.Audio);

            SaveControlsSettings(ref settings.Controls);
        }

        #region Display
        void LoadDisplaySettings(PersistentDisplay persistentDisplay, bool initialized)
        {
            if (!initialized)
            {
                ResetDisplaySettings();
                if (notifyPersistency) Debug.LogWarning("Graphics Settings was loaded, but null. Using default Values created.");
                return;
            }
            fov.SetValue(persistentDisplay.FOV);
            fullscreen.SetValue(persistentDisplay.Fullscreen);
            if (notifyPersistency) Debug.Log("Graphics Settings was loaded, successfully.");
        }

        void SaveDisplaySettings(ref PersistentDisplay persistentDisplay)
        {
            persistentDisplay = new PersistentDisplay(
            fullscreen.Value,
            fov.Value
            );
            if (notifyPersistency) Debug.Log("Graphics Settings was saved sucessfully.");
        }

        void ResetDisplaySettings()
        {
            // Check for the device information to adjust the default ??
            fov.UseDefault();
            fullscreen.UseDefault();
        }

        #endregion

        #region Audio
        void LoadAudioSettings(PersistentAudio persistentAudio, bool initialized)
        {
            if (!initialized)
            {
                ResetAudioSettings();
                if (notifyPersistency) Debug.LogWarning("Audio Settings was loaded, but null. Using default Values created.");
                return;
            }

            masterVolume.SetValue(persistentAudio.MasterVolume);
            musicVolume.SetValue(persistentAudio.MusicVolume);
            sfxVolume.SetValue(persistentAudio.SFXVolume);
            uiVolume.SetValue(persistentAudio.UIVolume);
            if (notifyPersistency) Debug.Log("Audio Settings was loaded, successfully.");
        }

        void SaveAudioSettings(ref PersistentAudio persistentAudio)
        {
            persistentAudio = new PersistentAudio(
            masterVolume.Value,
            musicVolume.Value,
            sfxVolume.Value,
            uiVolume.Value
            );
            if (notifyPersistency) Debug.Log("Audio Settings was saved sucessfully.");
        }

        void ResetAudioSettings()
        {
            masterVolume.UseDefault();
            musicVolume.UseDefault();
            sfxVolume.UseDefault();
            uiVolume.UseDefault();
        }

        #endregion

        #region Controls
        void LoadControlsSettings(PersistentControls persistentControls, bool initialized)
        {
            if (!initialized)
            {
                ResetControlsSettings();
                if (notifyPersistency) Debug.LogWarning("Controls Settings was loaded, but null. Using default Values created.");
                return;
            }

            xInverted.SetValue(persistentControls.XInverted);
            yInverted.SetValue(persistentControls.YInverted);
            xsensitivity.SetValue(persistentControls.XSensitivity);
            ysensitivity.SetValue(persistentControls.YSensitivity);
            if (notifyPersistency) Debug.Log("Controls Settings was loaded, successfully.");
        }

        void SaveControlsSettings(ref PersistentControls persistentControls)
        {
            persistentControls = new PersistentControls(
            xInverted.Value,
            yInverted.Value,
            xsensitivity.Value,
            ysensitivity.Value
            );
            if (notifyPersistency) Debug.Log("Controls Settings was saved sucessfully.");
        }

        void ResetControlsSettings()
        {
            xInverted.UseDefault();
            yInverted.UseDefault();
            xsensitivity.UseDefault();
            ysensitivity.UseDefault();
        }

        #endregion
    }
}
