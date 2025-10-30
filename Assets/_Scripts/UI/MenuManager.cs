using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject helpPanel;

    public AudioSource audioSource;
    public AudioClip clickSound;

    private void PlayClick()
    {
        if (audioSource != null && clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }

    public void StartGame()
    {
        PlayClick();
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame()
    {
        PlayClick();
        Application.Quit();
    }

    public void OpenSettings()
    {
        PlayClick();
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OpenHelp()
    {
        PlayClick();
        mainPanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    public void ClosePanels()
    {
        PlayClick();
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        helpPanel.SetActive(false);
    }
}
