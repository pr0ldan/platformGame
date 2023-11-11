using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "End" || collision.transform.tag == "Trap") {
            if (collision.transform.tag == "End")
            {
                PlayerManager.isLevelComplete = true;
                PlayerManager.lastCheckpointPos = new Vector2(0, 20);
            }
            else
            {
                PlayerManager.isGameOver = true;
            }
            gameObject.SetActive(false);
            //PlayerManager.lastCheckpointPos = new Vector2(-7, 0);
        }
    }
}
