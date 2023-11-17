using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRunPlayer : MonoBehaviour
{
    public Animator animator;
    float timePassed = 0f;
    bool isRight = true;

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 1f && timePassed < 3f) //1 second: move right
        {
            if(!isRight)
            {
                Flip();
                isRight = true;
            }
            Walk();
        }
        else if (timePassed > 3f && timePassed < 4f) //3 seconds: stop moving
        {
            Stop();
        }
        else if (timePassed > 4f && timePassed < 6f) //4 seconds: move left
        {
            if(isRight)
            {
                Flip();
                isRight = false;
            }
            Walk();
        }
        else if (timePassed > 6f) //6 seconds: stop moving
        {
            Stop();
            timePassed = 0f; //reset
        }
    }

    void Flip() //flip character
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    void Walk()
    {
        animator.ResetTrigger("Idle");
        animator.SetTrigger("Walk");
    }
    void Stop()
    {
        animator.ResetTrigger("Walk");
        animator.SetTrigger("Idle");
    }
}
