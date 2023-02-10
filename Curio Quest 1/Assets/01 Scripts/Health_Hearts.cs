using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health_Hearts : MonoBehaviour
{
    public int health;
    public int numHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite noHeart;

    private Animator anim;
    private Rigidbody2D rb;

    private Vector3 respawnPoint;
    [SerializeField] private AudioSource deathSfx;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        respawnPoint = transform.position;
    }

    private void Update () 
    {
        for(int i = 0; i < hearts.Length; i++) 
        {
            //check health doesn't exceed number of hearts
            if (health > numHearts){
                health = numHearts;
            }
            
            //check whether i is smaller than the amount of health
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else{
                hearts[i].sprite = noHeart;
            }

            //run the loop as long the variable is less than the number of hearts
            if(i < numHearts){
                hearts[i].enabled = true;
            }
            else{
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage()
    {
        deathSfx.Play();
        rb.bodyType = RigidbodyType2D.Static;
        //decrease health by one
        health--;
        
        if (health != 0)
        {
            anim.SetTrigger("Death");
            StartCoroutine(WaitRespawn());                       
        }
        else
        {
            anim.SetTrigger("Death");
            StartCoroutine(WaitGameOver());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            // deathSfx.Play();
            // rb.bodyType = RigidbodyType2D.Static;
            //anim.SetTrigger("Death");
            
            // //decrease health by one
            // health--;

            TakeDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Checkpoint")
        {
            // transform.position = respawnPoint;
            respawnPoint = transform.position;
        }
        // else if(other.tag == "Checkpoint")
        // {
        //     respawnPoint = transform.position;
        // }
    }

    private IEnumerator WaitRespawn()
    {
        yield return new WaitForSeconds(1.5f);
        transform.position = respawnPoint;
        //anim.ResetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("GoBack");
    }

    private IEnumerator WaitGameOver()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(4);
    }
}
