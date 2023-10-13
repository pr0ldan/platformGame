using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody rb;
    private Animator anim;
    private Transform currentPath;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        currentPath = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPath.position - transform.position;
        if(currentPath == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed - speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPath.position) < 0.5f && currentPath == pointB.transform)
        {
            currentPath = pointA.transform;
        }
        
        if(Vector2.Distance(transform.position, currentPath.position) < 0.5f && currentPath == pointA.transform)
        {
            currentPath = pointB.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
