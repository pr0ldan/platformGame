using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;
    public Animator animator;
    public GameObject bullet;
    public Transform bulletHole;
    public float force = 500;
    public AudioSource shootSound;

    void Awake() {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Shoot.performed += context => Fire();
    }

    void Fire() {
        animator.SetTrigger("Shoot");
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);
        bullet.tag = "Bullet";
       
        if(GetComponent<PlayerMovement>().faceRight) {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        }
        else {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
        }

        shootSound.Play();

        Destroy(go, 1.5f);
    }
}
