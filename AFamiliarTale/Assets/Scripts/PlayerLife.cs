using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerLife : MonoBehaviour
{
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public Vector3 respawnPoint;

    private void Start()
    {
        currentHealth = 3;
        respawnPoint = PlayerManager.lastCheckpointPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
		{
            currentHealth--;
            if (currentHealth <= 0)
            {
                PlayerManager.numberOfCoins = PlayerManager.numberOfCoins - 3;

                if (PlayerManager.numberOfCoins < 0) {
                    PlayerPrefs.SetInt("NumberOfCoins", 0);
                    PlayerPrefs.Save();
                }
                else {
                    PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);
                    PlayerPrefs.Save();
                }

                //gameObject.transform.tag = "End";
                Destroy(gameObject);
                PlayerManager.isGameOver = true;
            }
            Update() ;
            transform.position = respawnPoint;

        }
    }

    private void Update()
    {
        healthText.SetText(currentHealth.ToString());
        respawnPoint = PlayerManager.lastCheckpointPos;
    }
}
