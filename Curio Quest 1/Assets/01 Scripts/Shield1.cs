using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//To make sure this class works only if box collider is present
[RequireComponent(typeof(BoxCollider2D))]

public class Shield1 : MonoBehaviour
{    
    //Interactable Objects (pop-up E)
    public GameObject interactIcon;

    private void Start() 
    {
        interactIcon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            OpenInteractableIcon();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            CloseInteractableIcon();
        }
    }

    public void OpenInteractableIcon(){
        interactIcon.SetActive(true);
    }

    public void CloseInteractableIcon(){
        interactIcon.SetActive(false);
    }

    public void ShowBox()
    {
        
    }
}
