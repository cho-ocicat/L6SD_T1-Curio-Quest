using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_CollectItem1 : MonoBehaviour
{
    private int CountKey = 0;
    public int numKeys;

    public Image[] keys;
    public Sprite gotKey;
    public Sprite noKey;

    List<Collider2D> inColliders = new List<Collider2D>();
    public GameObject target;
    public string messageOn;
    public string messageOff;
    public bool isOpened;

    [SerializeField] private AudioSource pickSfx;
  

    private void Start() {
        keys[0].sprite = noKey;
        keys[1].sprite = noKey;
        keys[2].sprite = noKey;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("IronKey")){
            pickSfx.Play();
            Destroy(collision.gameObject);
            
            KeyNumber();
            TotalKeys();
        }
    }

    public void KeyNumber()
    {
        CountKey++;

        for(int i = 0; i < keys.Length; i++) 
        {
            //check CountKey doesn't exceed number of keys
            if (CountKey > numKeys){
                CountKey = numKeys;
            }
            
            //check whether i is smaller than the amount of CountKey
            if (i < CountKey)
            {
                keys[i].sprite = gotKey;
            }
            else{
                keys[i].sprite = noKey;
            }

            //run the loop as long the variable is less than the number of keys
            if(i < numKeys){
                keys[i].enabled = true;
            }
            else{
                keys[i].enabled = false;
            }
        }
    }

    private void TotalKeys () {
        if (CountKey == 3)
        {
            inColliders.ForEach(n=>n.SendMessage("Open", SendMessageOptions.DontRequireReceiver));
        }
    }

    public void OpentheDoor()
    {
        if(!isOpened){
            SetState(true);
        }
    }

    public void ClosetheDoor()
    {
        if(isOpened){
            SetState(false);
        }
    }
    
    public void Toggle()
    {
        if (!isOpened){
            OpentheDoor();
        }
        else {
            ClosetheDoor();
        }
    }

    void SetState(bool openGate)
    {
        isOpened = openGate;
        if(openGate)
        {
            if (target != null && !string.IsNullOrEmpty(messageOn))
            {
                target.SendMessage(messageOn);
            }
        }
        else{
            if (target != null && !string.IsNullOrEmpty(messageOff))
            {
                target.SendMessage(messageOff);
            }
        }
    }

    // private IEnumerator WaitforSfx()
    // {
    //     yield return new WaitForSeconds(6f);
    // }
}
