using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int temp;
    private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.transform.tag == "End") //level complete
            {
                PlayerManager.isLevelComplete = true;
                PlayerManager.lastCheckpointPos = new Vector2(-12f, -5f);
                gameObject.SetActive(false);
            }
    }
}
