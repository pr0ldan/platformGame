using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{  
    public GameObject pauseMenuScreen;
    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;

    public static bool isGameOver;
    public static bool isLevelComplete;
    public static Vector2 lastCheckpointPos = new Vector2(-12f, -5f);

    public static bool isCustom;
    public static bool isCustom2;

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    public static int numberOfStars;
    public TextMeshProUGUI starsText;

    public GameObject custm, custm2;

    public static AudioSource [] collectSounds;
    public AudioSource winSound;
    public AudioSource loseSound;
    public AudioSource pauseSound;
    public AudioSource resumeSound;
    public AudioSource selectSound;
    public AudioSource music;

    private bool playWinSound = true;
    private bool playLoseSound = true;

    private void Awake() {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        numberOfStars = PlayerPrefs.GetInt("NumberOfStars", 0);
        isGameOver = false;
        isLevelComplete = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpointPos;
        collectSounds = GetComponents<AudioSource>();
    }
    public void PauseGame()
    {
        music.Pause();
        pauseSound.Play();

        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        music.UnPause();
        resumeSound.Play();
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GotToMainMenu()
    {
        StartCoroutine(GotToMainMenu2());
    }

    IEnumerator GotToMainMenu2()
    {
        selectSound.Play();
        yield return new WaitForSecondsRealtime(.13f);
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel()
    {
        StartCoroutine(NextLevel2());
    }

    IEnumerator NextLevel2()
    {
        selectSound.Play();
        yield return new WaitForSecondsRealtime(.13f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReplayLevel()
    {
        StartCoroutine(ReplayLevel2());
    }

    IEnumerator ReplayLevel2()
    {
        selectSound.Play();
        yield return new WaitForSecondsRealtime(.13f);
        PlayerManager.lastCheckpointPos = new Vector2(-12f, -5f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public static void CoinSound()
    {
        collectSounds[0].Play();
    }
    public static void StarSound()
    {
        collectSounds[1].Play();
    }

    void Update() {
        //Debug.Log(numberOfCoins);
        coinsText.text = numberOfCoins.ToString();
        starsText.text = numberOfStars.ToString();

        if(isGameOver)
        {
            if(playLoseSound)
            {
                loseSound.Play();
                playLoseSound = false;
            }
            music.Stop();
            gameOverScreen.SetActive(true);
        }
        else if (isLevelComplete)
        {
            if (playWinSound)
            {
                winSound.Play();
                playWinSound = false;
            }
            levelCompleteScreen.SetActive(true);

            //update level progress
            if (SceneManager.GetActiveScene().buildIndex + 1 > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", SceneManager.GetActiveScene().buildIndex + 1);
            }
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
}
