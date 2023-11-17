using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
	private Animator anim;
	private int Life = 3;
	private Rigidbody2D rb;

	private PlayerManager playerManager;
	
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

    public void ReplayLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }


    private void Die()
	{
		rb.bodyType = RigidbodyType2D.Static;
		ReplayLevel();
		anim.SetTrigger("death");
	}
}
