using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRight : MonoBehaviour
{
    float timePassed = 0f;
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 2f) //every 2 seconds
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        if (timePassed > 4f) //revert back
        {
            GetComponent<SpriteRenderer>().color = new Color32(180, 180, 180, 255);
            timePassed = 0f;
        }
    }
}
