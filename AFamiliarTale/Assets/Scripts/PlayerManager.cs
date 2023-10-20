using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{  
    public GameObject pauseMenuScreen;
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static Vector2 lastCheckpointPos = new Vector2(-7, 0);

    private void Awake() {
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpointPos;
    }

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

    void Update() {
        if(isGameOver) {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
