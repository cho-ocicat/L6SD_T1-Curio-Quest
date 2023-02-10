using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    public bool isOpen;
    private BoxCollider2D doorCollider;

    [SerializeField] private AudioSource gateSfx;
    
    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    public void Open()
    {
        if(!isOpen){
            SetState(true);
            gateSfx.Play();
        }
    }

    public void Close()
    {
        if(isOpen){
            SetState(false);
        }
    }

    public void Toggle()
    {
        if (isOpen){
            Close();
        }
        else {
            Open();
        }
    }

    //where it changes the state of the door. Place of the other functions
    void SetState(bool openDoor)
    {
        isOpen = openDoor;
        //set openDoor instead of enabled so that it can still execute trigger events
        doorCollider.isTrigger = openDoor;
    }
}
