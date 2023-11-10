using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;

    private float speed = 1f;
    private float timePassed = 0f;

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 1f && timePassed < 4f) //1 second: right
        {
            currentWaypoint = 0;
        }
        else if (timePassed > 4f && timePassed < 6f) //4 seconds: left
        {
            currentWaypoint = 1;
        }
        else if (timePassed > 6f) //6 seconds: reset
        {
            timePassed = 0f; //reset
        }

        if((timePassed > 1f && timePassed < 3f) || (timePassed > 4f && timePassed < 6f))
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
        }
    }
}