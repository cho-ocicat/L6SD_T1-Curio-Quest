using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys_Collect : MonoBehaviour
{
    public string whichKey;

     public GameObject target;
    public string messageOn;
    public string messageOff;
    public bool isCollected;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Lists off all keys: " + whichKey);
    }

    public void Collected()
    {
        if(!isCollected){
            SetState(true);
        }
    }

    public void TurnOff()
    {
        if(isCollected){
            SetState(false);
        }
    }
    
    public void Toggle()
    {
        if (!isCollected){
            Collected();
        }
        else {
            TurnOff();
        }
    }

    void SetState(bool openGate)
    {
        isCollected = openGate;
        if(openGate)
        {
            if (target != null && !string.IsNullOrEmpty(messageOn))
            {
                target.SendMessage(messageOn);
            }
        }
        else
        {
            if (target != null && !string.IsNullOrEmpty(messageOff))
            {
                target.SendMessage(messageOff);
            }
        }
    }
}
