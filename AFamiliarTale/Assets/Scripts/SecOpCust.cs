using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecOpCust : MonoBehaviour
{
    public Button square2;
    public int price;
    public void ChangeConf() {
        PlayerManager.isCustom2 = true;
        PlayerManager.isCustom = false;
    }
     public void UpdateUI() {
        if (PlayerPrefs.GetInt("NumberOfCoins", 0) < price)
        {
            Debug.Log("price is less");
            square2.gameObject.SetActive(true);
            square2.interactable = false;
        }
        else
        {
            square2.gameObject.SetActive(true);
            square2.interactable = true;
        }
    }
}

