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
        if (timePassed > 1f && timePassed < 3f) //1 second: press right
        {
            Press(right, true);
        }
        else if (timePassed > 3f && timePassed < 4f) //3 seconds: stop press right
        {
            Press(right, false);
        }
        else if (timePassed > 4f && timePassed < 6f) //4 seconds: press left
        {
            Press(left, true);
        }
        else if (timePassed > 6f) //6 seconds: stop press left
        {
            Press(left, false);
            timePassed = 0f; //reset
        }
    }

    void Press(GameObject btn, bool press)
    {
        if(press)
        {
            btn.GetComponent<SpriteRenderer>().color = new Color32(180, 180, 180, 255);
        }
        else
        {
            btn.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }
}