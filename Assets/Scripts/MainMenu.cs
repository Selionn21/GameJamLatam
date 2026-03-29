using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;     
    public GameObject creditsPanel;

    private void Start()
    {
        Time.timeScale = 0f; 
        mainPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void StartGame()
    {
        Time.timeScale = 1f; 
        mainPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        creditsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void Retry()
    {

        SceneManager.GetActiveScene();

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}