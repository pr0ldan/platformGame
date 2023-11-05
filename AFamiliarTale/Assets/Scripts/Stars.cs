using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Player") {
            PlayerManager.numberOfStars = PlayerManager.numberOfStars + 3;
            PlayerPrefs.SetInt("NumberOfStars", PlayerManager.numberOfStars);
            Destroy(gameObject);
        }
    }
}
