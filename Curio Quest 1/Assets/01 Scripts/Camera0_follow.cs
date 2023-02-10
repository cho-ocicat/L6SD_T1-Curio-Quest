using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera0_follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    //set velocity to zero?
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate(){
        //limits camera movement upon reaching certain point
        //Mathf.Clamp is used to set (interval, min, max) values
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, 0f, 50.7f),
            Mathf.Clamp(target.position.y, -0.5f, 6.3f), 
            transform.position.z);
    }

    void LastUpdate()
    {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
