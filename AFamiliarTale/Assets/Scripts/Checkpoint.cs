using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour//, //DataInterface
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == "Player")
        {
            PlayerManager.lastCheckpointPos = transform.position;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
