using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    //sets what enemy will chase
    public GameObject player;
    public GameObject enemy;

    //adjustable speed
    public float speed;

    //adjustable chase distance
    public int disBetween;

    public int health;

    //for enemy return
    public Vector3 start;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //path creator from enemy to player
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        //enemy chase
        if (distance < disBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        //enemy with return to spawn point
        if (distance > disBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, start, speed * Time.deltaTime);

        }
    }

    //for sprites that way they don't face the wrong way
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemy.CompareTag("Trap") == collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            print(health);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
