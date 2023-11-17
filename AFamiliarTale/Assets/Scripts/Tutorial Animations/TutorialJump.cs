using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialJump : MonoBehaviour
{
    public Animator animator;
    public GameObject btn;
    public GameObject player;

    float timePassed = 0f;

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 2f && timePassed < 3f) //2 seconds: jump
        {
            btn.GetComponent<SpriteRenderer>().color = new Color32(180, 180, 180, 255); //push button
            animator.SetBool("Jump", true);
        }
        else if (timePassed > 3f) //3 seconds: land
        {
            btn.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); //stop pushing button
            animator.SetBool("Jump", false);

            timePassed = 0f; //reset
        }
    }
}