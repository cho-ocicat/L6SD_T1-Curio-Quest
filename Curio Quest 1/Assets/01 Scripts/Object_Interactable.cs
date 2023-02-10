using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To make sure this class works only if box collider is present
[RequireComponent(typeof(BoxCollider2D))]

public class Object_Interactable : MonoBehaviour
{    
    //make sure In Trigger is ticked on for this to work
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player"))
        collision.GetComponent<Player_move1>().OpenInteractableIcon();
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player_move1>().CloseInteractableIcon();
        }
    }
}
