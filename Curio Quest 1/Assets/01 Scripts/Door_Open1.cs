using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open1 : MonoBehaviour
{
    public bool isOpen;
    private BoxCollider2D doorCollider;
    private Animator anim;

    //private List<string> allKeys;

    [SerializeField] private AudioSource gateSfx;
    
    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        //allKeys = GetComponent<Player_CollectItem>().itemKeys;
    }

    void Update()
    {
    }

    public void Open()
    {
        if(!isOpen){
            SetState(true);
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
        anim.SetBool("DoorOpening", openDoor);
        gateSfx.Play();

        //set openDoor instead of enabled so that it can still execute trigger events
        doorCollider.isTrigger = openDoor;
    }
}
