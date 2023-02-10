using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_CollectItem : MonoBehaviour
{
    private int CountKey = 0;
    public int numKeys;

    public Image[] keys;
    public Sprite gotKey;
    public Sprite noKey;

    //to collect the string names of the keys
    //public List<string> itemKeys;
    public GameObject getDoor;

    [SerializeField] private AudioSource pickSfx;
  

    private void Start() {
        keys[0].sprite = noKey;
        keys[1].sprite = noKey;
        keys[2].sprite = noKey;

        getDoor = GameObject.FindGameObjectWithTag("Gate");

        //itemKeys = new List<string>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("IronKey")){
            pickSfx.Play();
            Destroy(collision.gameObject);
            CountKey++;

            // string whichKey = collision.gameObject.GetComponent<Keys_Collect>().whichKey;
            // itemKeys.Add(whichKey);
            
            KeyNumber();
            TotalKeys();
        }
    }

    public void KeyNumber()
    {
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

    private void TotalKeys()
    {
        if (CountKey == 3)
        {
            getDoor.SendMessage("Open");
        }
    }
}
