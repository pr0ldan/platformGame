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

    public static bool isCustom;
    public static bool isCustom2;

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    public static int numberOfStars;
    public TextMeshProUGUI starsText;

    public GameObject custm, custm2;

    private void Awake() {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        numberOfStars = PlayerPrefs.GetInt("NumberOfStars", 0);
        isGameOver = false;
        isLevelComplete = false;
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
        starsText.text = numberOfStars.ToString();

        if(isGameOver) {
            gameOverScreen.SetActive(true);
        }
        else if (isLevelComplete)
        {
            levelCompleteScreen.SetActive(true);
        }

        if (isCustom) {
            custm.SetActive(true);
        }
        else if (isCustom2) {
            custm2.SetActive(true);
        }
        else {
            custm.SetActive(false);
            custm2.SetActive(false);
        }
    }

    public void ReplayLevel() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
