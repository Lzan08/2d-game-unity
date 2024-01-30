using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    public GameObject[] brainSprites;
    public Sprite spritBrainLoss;
    public int BrainCount;
    public GameObject Jigsaw;
    public Transform waypoint;

    private Rigidbody2D rb;
    private Animator anim;
    private void Start()


    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (BrainCount > 0)
            {
                BrainCount--;
                brainSprites[BrainCount].GetComponent<Image>().sprite = spritBrainLoss;
                Resetobject();

            }
            if (BrainCount <= 0)
            {
                Die();
            }
        }
    }

    private void Resetobject()
    {
        if (Jigsaw != null)
        {
            Jigsaw.transform.position = waypoint.position;
        }
    }
    private void Die()
    {
        Debug.Log('0');
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
