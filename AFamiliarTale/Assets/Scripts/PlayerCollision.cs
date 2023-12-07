using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int temp;
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "End" || collision.transform.tag == "Trap") {
            if (collision.transform.tag == "End") //level complete
            {
                PlayerManager.isLevelComplete = true;
                PlayerManager.lastCheckpointPos = new Vector2(-12f, -5f);
            }
            else //game over
            {
                temp = PlayerManager.numberOfCoins - 3;

                if (temp < 0) {
                    PlayerManager.numberOfCoins = 0;
                }
                else {
                    PlayerManager.numberOfCoins = temp;
                }

                PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);
                PlayerManager.isGameOver = true;
            }

            gameObject.SetActive(false);
            PlayerManager.lastCheckpointPos = new Vector2(-12f, -5f);
        }
    }
}
