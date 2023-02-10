using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Switch : MonoBehaviour
{
    public GameObject target;
    public string messageOn;
    public string messageOff;
    public bool isTurned;

    Animator anim;
    [SerializeField] private AudioSource leverSfx;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn()
    {
        if(!isTurned){
            SetState(true);
            leverSfx.Play();
        }
    }

    public void TurnOff()
    {
        if(isTurned){
            SetState(false);
        }
    }
    
    public void Toggle()
    {
        if (!isTurned){
            TurnOn();
        }
        else {
            TurnOff();
        }
    }

    void SetState(bool turnSwitch)
    {
        isTurned = turnSwitch;
        anim.SetBool("TurnRight", turnSwitch);
        if(turnSwitch)
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
}
