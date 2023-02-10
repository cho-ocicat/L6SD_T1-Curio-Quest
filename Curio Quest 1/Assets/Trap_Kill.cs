using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap_Kill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player"))
        {
            //StartCoroutine(LoadScene());
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    private IEnumerator LoadScene() {
        yield return new WaitForSeconds(2f);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
