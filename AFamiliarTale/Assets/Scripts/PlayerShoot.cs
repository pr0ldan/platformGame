using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;
    public Animator animator;

    void Awake() {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Shoot.performed += context => Fire();
    }

    void Fire() {
        animator.SetTrigger("Shoot");
    }
}
