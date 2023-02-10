using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_EKey : MonoBehaviour
{
    //Interactable Objects (pop-up E)
    public GameObject interactIcon;

    // Start is called before the first frame update
    void Start()
    {
        interactIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //for interacting with object
        if(Input.GetKeyDown(KeyCode.E)){
            CheckInteraction();
        }
    }

    //for E key popping up
    public void OpenInteractableIcon(){
        interactIcon.SetActive(true);
    }

    public void CloseInteractableIcon(){
        interactIcon.SetActive(false);
    }
    //raycasting, specifically box casting. Put a box around target object and check for any colliders inside and return the hit value
    private void CheckInteraction()
    {
        //BoxCastAll(origin point, box size (x,y,z),angle of box, direction of box)
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, new Vector2(0.4f, 0.3f), 0, Vector2.zero);

        if(hits.Length > 0){
            foreach (RaycastHit2D rc in hits)
            {
                //Interact function from Object_Interactable
                if(rc.transform.GetComponent<Object_Interactable>()) {
                    rc.transform.GetComponent<Object_Interactable>();

                    //if you don't want to interact with every object under range
                    //return;
                }
            }
        }
    }

}
