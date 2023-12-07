using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeleteData : MonoBehaviour
{
    public void deleteData()
    {
        PlayerPrefs.DeleteAll(); //resets level progress
    }
}
