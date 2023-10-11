using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{  
    public GameObject pauseMenuScreen;
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame() {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GotToMainMenu() {
        SceneManager.LoadScene("Menu");
    }
}
