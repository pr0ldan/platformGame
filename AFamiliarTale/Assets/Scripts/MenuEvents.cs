using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource selectSound;
    public void Start() {
        Time.timeScale = 1;
    }
    public void LoadLvl(int index) //index will pass level number(1, 2, ..., n)
    {
        SceneManager.LoadScene(index);
    }


    public void LoadLevel(int index) //index will pass level number(1, 2, ..., n)
    {
        StartCoroutine(LoadLvl2(index));
    }
    IEnumerator LoadLvl2(int index)
    {
        selectSound.Play();
        yield return new WaitForSecondsRealtime(.13f);
        SceneManager.LoadScene(index);
    }
}