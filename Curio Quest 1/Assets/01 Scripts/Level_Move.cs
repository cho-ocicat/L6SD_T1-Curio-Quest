using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//[RequireComponent(typeof(BoxCollider2D))]
public class Level_Move : MonoBehaviour
{
    //File -> Build Settings to check open scenes
    private int nextScene;
    public Animator anim;

    // //to make sure any component receiving this script automatically has box collider 2d on with is trigger ticked
    // private void Reset() {
    //     GetComponent<BoxCollider2D>().isTrigger = true;
    // }

    private void Start() {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")){

            StartCoroutine(Transition());
        }
    }

    private IEnumerator Transition()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(0.01f);
        //Single mode to let only a level loaded at the same time
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
