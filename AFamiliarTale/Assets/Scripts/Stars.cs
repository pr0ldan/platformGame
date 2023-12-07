using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public int numStars;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Player") {           
            numStars = numStars + 2;
            PlayerManager.StarSound();
            Destroy(gameObject);
        }
    }
}
