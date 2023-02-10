using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Level_End : MonoBehaviour
{
    //File -> Build Settings to check open scenes

    public SpriteRenderer sr;
    public Sprite doorOpen;

    //to make sure any component receiving this script automatically has box collider 2d on with is trigger ticked
    private void Reset() {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")){
            //Single mode to let only a level loaded at the same time
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
    }
    
    public void ChangeSprite()
    {
        sr.sprite = doorOpen;
    }
}
