using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    AudioManager audio;

    public bool ifPause { get; set; }

#region MenuItems

    [Header("Menu items")]

    [SerializeField]
    Window startMenu;

    [SerializeField]
    Window gameUI;

    [SerializeField]
    Window settingsMenu;

    [SerializeField]
    Window settingMenu;

    [SerializeField]
    Window pauseMenu;
    

#endregion

#region Buttons

    [Header("Buttons")]

    [SerializeField]
    Button pauseButton;

    [SerializeField]
    Button settingsButton;

    [SerializeField]
    Button backButton;

    [SerializeField]
    Button resumeButton;

    [SerializeField]
    Button resetButton;

    [SerializeField]
    Button playButton;

#endregion

    private void Awake()
    {
        Time.timeScale = 0;

        pauseButton.onClick.AddListener(OnPauseButtonClick);
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);
        resumeButton.onClick.AddListener(OnResumeButtonClick);
        resetButton.onClick.AddListener(OnResetButtonClick);
        playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDestroy()
    {
        pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        backButton.onClick.RemoveListener(OnBackButtonClick);
        resumeButton.onClick.RemoveListener(OnResumeButtonClick);
        resetButton.onClick.RemoveListener(OnResetButtonClick);
        playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void Update()
    {
        UpdateExitInput();
    }

    public void OnPlayButtonClick()
    {
        audio.OnClickButton.Play();
        Time.timeScale = 1.0f;
        startMenu.Hide();
        gameUI.Show();
    }

    public void OnSettingsButtonClick()
    {
        audio.OnClickButton.Play();
        settingsMenu.Show();
        pauseMenu.Hide();
    }

    public void OnPauseButtonClick()
    {
        ifPause = !ifPause;
        audio.OnClickButton.Play();
        Time.timeScale = 0.0f;
        pauseMenu.Show();
        gameUI.Hide();
    }

    public void OnBackButtonClick()
    {
        audio.OnClickButton.Play();
        pauseMenu.Show();
        settingsMenu.Hide();
    }

    public void OnResumeButtonClick()
    {
        ifPause = !ifPause;
        audio.OnClickButton.Play();
        pauseMenu.Hide();
        gameUI.Show();
        Time.timeScale = 1.0f;
    }

    public void OnResetButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    void UpdateExitInput()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

}
