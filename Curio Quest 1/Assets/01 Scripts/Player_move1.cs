using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_move1 : MonoBehaviour
{
    private float horzInput;
    private float speed = 10f;
    private bool isFacingRight = true;
    //serializeField lets you edit directly from Unity
    [SerializeField] private float jumpingPower;
    private Animator anim;

    //Interactable Objects (pop-up E)
    public GameObject interactIcon;

    //list of switches
    List<Collider2D> inColliders = new List<Collider2D>();

    //create a method that deals with all movement animation
    //The enum method put index number on the variables inside {}, which is assigned on Animator parameter, transition.
    private enum MovementState{idle, running, jumping, falling}
    
    //audio variable
    bool isMoving = false;
    [SerializeField] private AudioSource runSfx;
    [SerializeField] private AudioSource jumpSfx;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent will reference the Player's components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        interactIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis returns the value of -1 (left), 0 (no key pressed), +1 (right)
        horzInput = Input.GetAxis("Horizontal");   
        anim.SetBool("Grounded", isGrounded());

        if (rb.velocity.x != 0 && rb.velocity.y == 0)
        {
            isMoving = true;
        }
        else {
            isMoving = false;
        }

        if (isMoving){
            if (!runSfx.isPlaying)
            {
                runSfx.Play();
            }
        }
        // else {
        //     runSfx.Stop();
        // }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            jumpSfx.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        //jump higher by longer key press. Normal jump by short key press
        if (Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //for interacting with object
        if(Input.GetKeyDown(KeyCode.E)){
            CheckInteraction();
            
            inColliders.ForEach(n=>n.SendMessage("TurnOn", SendMessageOptions.DontRequireReceiver));
        }

        Flip();
        AnimationState();
    }

    void FixedUpdate()
    {
        //using vector to assign velocity in all direction
        rb.velocity = new Vector2(horzInput*speed, rb.velocity.y);
    }


    private void Flip()
    {
        if (isFacingRight && horzInput < 0f || !isFacingRight && horzInput > 0f )
        {
            Vector3 currentScale = transform.localScale;
            //times -1. If facing left, -1*-1=1 (right)
            currentScale.x *= -1f;
            transform.localScale = currentScale;
            
            //equal to what it currently is. true to false, false to true
            isFacingRight = !isFacingRight;
        }
        
    }

    private bool isGrounded()
    {
        //ground check is done by masked circle (overlap). The size is its radius, and it's masked (groundLayer)
        return Physics2D.OverlapCircle(groundCheck.position, 0.04f, groundLayer);
    }

    private void AnimationState(){
        MovementState state;

        if (horzInput > 0f){
            state = MovementState.running;
        }
        else if (horzInput < 0f){
            state = MovementState.running;
        }
        else {
            state = MovementState.idle;
        }

        //run is top priority, then jump, then fall. The arrangement is to make sure running animation doesn't play during jump/fall
        if (rb.velocity.y > 0.1f){
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f){
            state = MovementState.falling;
        }

        //(int) turns the enum into its corresponding integer on Animation Parameter
        anim.SetInteger("State", (int)state);
    }

    //for the switch
    private void OnTriggerEnter2D(Collider2D other) {
        inColliders.Add(other);
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

                // if(rc.transform.GetComponent<Shield1>())
                // {
                //     rc.transform.GetComponent<Shield1>().
                // }
            }
        }
    }
}
