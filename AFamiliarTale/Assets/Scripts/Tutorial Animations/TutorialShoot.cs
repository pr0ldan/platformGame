using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialShoot : MonoBehaviour
{
    public Animator animator;
    public GameObject btn;
    public GameObject player;

    float timePassed = 0f;

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 1.5f && timePassed < 2f) //1.5 seconds: start animation
        {
            animator.SetBool("Shoot", true);
        }
        if (timePassed > 2f && timePassed < 2.5f) //2 seconds: shoot
        {
            btn.GetComponent<SpriteRenderer>().color = new Color32(180, 180, 180, 255); //push button
            animator.SetBool("Shoot", false);
        }
        else if (timePassed > 2.5f && timePassed < 3f) //2.5 seconds: stop
        {
            btn.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); //stop pushing button
            animator.SetBool("Shoot", true);
        }
        else if (timePassed > 3f && timePassed < 3.5f) //3 seconds: shoot again
        {
            btn.GetComponent<SpriteRenderer>().color = new Color32(180, 180, 180, 255); //push button
            animator.SetBool("Shoot", false);
        }
        else if (timePassed > 3.5f) //3.5 seconds: stop
        {
            btn.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); //stop pushing button
            timePassed = 0f; //reset
        }
    }
}