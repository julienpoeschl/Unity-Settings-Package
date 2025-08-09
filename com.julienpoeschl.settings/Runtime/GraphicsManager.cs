using UnityEngine;

namespace Settings
{
    /// <summary>
    /// 
    /// </summary>
    public class GraphicsManager : MonoBehaviour
    {
        [Header("Setting")]
        [SerializeField] private BoolSetting fullscreen;

        [Header("Debugging")]
        [SerializeField] private bool notifyFullscreen;

        public static GraphicsManager Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
            Destroy(gameObject);
        }


        void OnEnable()
        {
            fullscreen.OnValueChanged += ChangeFullscreen;
            ChangeFullscreen(fullscreen.Value);
        }

        void OnDisable()
        {
            fullscreen.OnValueChanged -= ChangeFullscreen;
        }

        void ChangeFullscreen(bool fullscreen)
        {
            if (notifyFullscreen) Debug.Log("Fullscreen was set to: " + fullscreen + ".");
            Screen.fullScreen = fullscreen;
        }
    }
}
