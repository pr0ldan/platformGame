using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRun : MonoBehaviour
{
    public GameObject left;
    public GameObject right;

    float timePassed = 0f;

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 2f) //every 2 seconds
        {
            right.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            left.GetComponent<SpriteRenderer>().color = new Color32(180, 180, 180, 255);
        }
        if (timePassed > 4f) //revert back
        {
            right.GetComponent<SpriteRenderer>().color = new Color32(180, 180, 180, 255);
            left.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            timePassed = 0f;
        }
    }
}