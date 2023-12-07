using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCustom : MonoBehaviour
{
    public Button square1;
    public int price;
    public bool isPurchased;

    // public bool isUnlocked;
    public void ChangeConf() {
        PlayerManager.isCustom = true;
        PlayerManager.isCustom2 = false;
    }

    // public void CheckUnlock() {
    //     isUnlocked = false;
    // }

    public void UpdateUI() {
        if(isPurchased) {
            square1.interactable = true;
            return;
        }

        if (PlayerPrefs.GetInt("NumberOfCoins", 0) < price)
        {
            Debug.Log("price is less");
            square1.gameObject.SetActive(true);
            square1.interactable = false;
            isPurchased = false;
        }
        else
        {
            square1.gameObject.SetActive(true);

            PlayerManager.numberOfCoins = PlayerManager.numberOfCoins - price;
            PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);
            square1.interactable = true;
            isPurchased = true;
        }

    }
}
