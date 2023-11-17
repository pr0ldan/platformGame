using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;

    private float speed = 1f;
    private float timePassed = 0f;

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 2f && timePassed < 3f) //2 seconds: jump
        {
            currentWaypoint = 1;
            speed = 1f;
        }
        else if (timePassed > 3f) //3 seconds: land
        {
            currentWaypoint = 0;
            speed = 2f;
            timePassed = 0f; //reset
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }
}