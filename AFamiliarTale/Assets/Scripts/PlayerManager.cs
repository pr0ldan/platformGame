using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{  
    public GameObject pauseMenuScreen;
    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;
    public static bool isGameOver;
    public static bool isLevelComplete;
    public static Vector2 lastCheckpointPos = new Vector2(-10.5f, -4.993932f);

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    private void Awake() {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
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
        //Debug.Log(numberOfCoins);
        coinsText.text = numberOfCoins.ToString();

        if(isGameOver) {
            gameOverScreen.SetActive(true);
        }
        else if (isLevelComplete)
        {
            levelCompleteScreen.SetActive(true);
        }
    }

    public void ReplayLevel() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
