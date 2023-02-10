using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door_CheckInventory : MonoBehaviour
{
    //to check and identify script inside a component. Other way to Layer Mask
    private string colliderScript;
    //unity events
    [SerializeField] private UnityEvent enterCollision;
    [SerializeField] private UnityEvent exitCollision;

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.GetComponent(colliderScript))
        {
            enterCollision?.Invoke();
        }
    }
    private void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.GetComponent(colliderScript))
        {
            exitCollision?.Invoke();
        }
    }
}
