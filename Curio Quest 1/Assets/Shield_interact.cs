using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //use the library

public class Door_open : MonoBehaviour
{
    [SerializeField] private Text interactText;
    private bool interactAllowed;

    private void Start() {
        //disable text's visibility
        interactText.gameObject.SetActive(false);
    }

    private void Update(){
        if (interactAllowed && Input.GetKeyDown(KeyCode.E)){
            popUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name.Equals("Player")){
            interactText.gameObject.SetActive(true);
            interactAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.name.Equals("Player")){
            interactText.gameObject.SetActive(false);
            interactAllowed = false;
        }
    }

    public void popUp(){
        //show dialogue box

        //delete the text
        if (Input.GetKeyDown(KeyCode.E)){
            Destroy(gameObject);
        }
    }
}
