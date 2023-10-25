using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
{
    float timePassed = 0f;
    void Update()
    {
        timePassed += Time.deltaTime;    
        if(timePassed > 2f) //every 2 seconds
        {
            Flip();
            timePassed = 0f;
        }
    }

    //flip character
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
