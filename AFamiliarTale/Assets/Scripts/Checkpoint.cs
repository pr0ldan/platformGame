using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour//, //DataInterface
{
    public AudioSource sound;
    bool soundPlayed = false;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Player")
        {
            if(!soundPlayed)
            {
                sound.Play();
                soundPlayed = true;
            }
            PlayerManager.lastCheckpointPos = transform.position;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
