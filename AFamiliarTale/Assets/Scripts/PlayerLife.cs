using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
	private Animator anim;
	private int Life = 3;
	private Rigidbody2D rb;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy_proj"))
		{
			Life--;
			if(Life <= 0)
			{
				Die();
			}
		}
	}
	
	private void Die()
	{
		//rb.bodyType = RigidbodyType2D.Static;
		anim.SetTrigger("death");
	}
	
	private void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
