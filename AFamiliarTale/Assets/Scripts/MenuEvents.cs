using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void Start() {
        Time.timeScale = 1;
    }
    public void LoadLvl(int index) //index will pass level number(1, 2, ..., n)
    {
        SceneManager.LoadScene(index);
    }
}