using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Object_Openable : MonoBehaviour
{
    //this script is to change sprite when interacted with (open/close)

    //the direction refers to the lever
    public Sprite close;
    public Sprite open;
    
    private SpriteRenderer sr;
    private bool isOpen;

    //from Object_Interactable
    public void Interact(){
        /*if (Input.GetKeyDown(KeyCode.E)){
            sr.sprite = open;
            transform.position = new Vector2 (4.45f,-4.04f);
        }*/
        if (isOpen == true){
            sr.sprite = close;
        }
        else
        {
            sr.sprite = open;
            sr.transform.position = new Vector2 (4.45f,-4.04f);
        }

        isOpen = !isOpen;
    }

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = close;
    }

}
