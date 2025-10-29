using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject helpPanel;

    [Header("Audio")]
    public Slider volumeSlider;
    public AudioSource musicSource;

    void Start()
    {
        // Загрузка сохраненной громкости
        if (PlayerPrefs.HasKey("Volume"))
        {
            float volume = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = volume;
            volumeSlider.value = volume;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void OpenHelp()
    {
        mainPanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    public void CloseHelp()
    {
        mainPanel.SetActive(true);
        helpPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
