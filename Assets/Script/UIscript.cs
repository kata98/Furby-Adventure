using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{

    [SerializeField]
    GameObject deathPanel = default;

    [SerializeField]
    GameObject pausePanel = default,
               pauseButton = default;

    [SerializeField]
    GameObject settingsButton = default,
               settingsPanel = default;

    [SerializeField]
    GameObject winPanel = default;

    bool isDead;

    void Start()
    {
        isDead = false;
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("eggs", 0);
        SceneManager.LoadScene(1);
        unpause();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void ExitSettings()
    {
        settingsPanel.SetActive(false);
        settingsButton.SetActive(true);

    }

    public void LoadDeathPanel()
    {
        pauseButton.SetActive(false);
        isDead = true;
        deathPanel.SetActive(true);
    }

    public void GameOver()
    { 
       winPanel.SetActive(true);

    }

    public void MyMenu()
    {
        unpause();
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

    public void pause()
    {
        if (!isDead)
        {
            pauseButton.SetActive(false);
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void unpause()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
