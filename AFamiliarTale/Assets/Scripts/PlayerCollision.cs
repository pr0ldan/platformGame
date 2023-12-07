using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "End") {
            if (collision.transform.tag == "End") //level complete
            {
                PlayerManager.isLevelComplete = true;
                PlayerManager.lastCheckpointPos = new Vector2(-12f, -5f);
            }
            else //game over
            {
                PlayerPrefs.SetInt("NumberOfCoins", 0);
                PlayerPrefs.SetInt("NumberOfStars", 0);
                PlayerManager.isGameOver = true;
            }

            gameObject.SetActive(false);
            PlayerManager.lastCheckpointPos = new Vector2(-12f, -5f);
        }
    }
}
