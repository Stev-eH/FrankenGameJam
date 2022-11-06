using System;
using UnityEngine;

// Movement of Player in the Lampformer-Minigame

public class MoveLampFormer : MonoBehaviour
{
    public bool colliding = false; // variable to check whether lamp is colliding with other objects

    //public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);

    Rigidbody lamp_Rigidbody;
    public float speed = 0.1f;
    public GameObject character;
    public float side_Thrust = 10f; //force of horizontal movements (walking)
    public float jump_Thrust = 50f; //force of vertical movements (jumping)
    public float max_velocity_side = 2f; //max speed for horizontal movements
    public float max_velocity_jump = 0.01f; //max speed for vertical movements

    //Collision Flags & variables
    public string collidingObjectName = "none"; //Name of object player is colliding with
    private bool collidingWithLeft = false; //collision with frame
    private bool collidingWithRight = false; //collision with frame
    private bool collidingWithPlatformsideleft = false;
    private bool collidingWithPlatformsideright = false;
    private float startingoffsetx = 0; //Offset for Collision with moving platforms
    public bool lighton = false; //checks whether light of Player-Lamp is on

    private void OnCollisionStay(Collision col) //actions while Player is colliding with other objects
    {
        //checks whether Player is standing on a moving platform, and makes Player move along
        if (col.gameObject.transform.parent.name == "Dynamic_Platform" && col.gameObject.transform.position.y > transform.position.y - 0.41f)
        {
            //Debug.Log("huhu");
            transform.position += Vector3.right*((col.gameObject.transform.position.x - startingoffsetx) -transform.position.x);
        }
    }

    void OnCollisionEnter(Collision col) //actions when Player is colliding with other objects
    {
        colliding = true;
        
        //checks what player is colliding with
        if (col.gameObject.name == "Platform_Right") //Right Side of the Frame
        {
            collidingWithRight = true;
        }
        else if(col.gameObject.name == "Platform_Left") //Right Side of the Frame
        {
            collidingWithLeft = true;
        }
        else if(col.gameObject.name == "Battery") //Reached the Battery
        {
            //Collected battery
            lighton = true;
            
        }
        else if(col.gameObject.transform.parent.name == "Enemy") //Hit an enemy
        {
            //hit ghost
            if (lighton)
            {
                //Won
            }
            else
            {
                //Lost, Restart
                //Scene scene = SceneManager.GetActiveScene(); 
                //SceneManager.LoadScene(scene.name);
            }

        }
        else if (col.gameObject.transform.position.y>transform.position.y-0.4f) //Player hit platform from the side
        {
            if (col.gameObject.transform.position.x < transform.position.x)
            {
                collidingWithPlatformsideleft = true;
            }
            else
            {
                collidingWithPlatformsideright = true;
            }
            
        };

        if (col.gameObject.transform.parent.name == "Dynamic_Platform" && col.gameObject.transform.position.y > transform.position.y - 0.41f)
        {
            //Collision with left-right moving platform, standing on it
            startingoffsetx = col.gameObject.transform.position.x - transform.position.x;

        }
    }

    void OnCollisionExit (Collision col) //actions when Player is done colliding with other objects
    {
        //reset of all collision flags
        if (col.gameObject.name == "Platform_Right")
        {
            collidingWithRight = false;
        }
        else if (col.gameObject.name == "Platform_Left")
        {
            collidingWithLeft = false;
        };
        collidingWithPlatformsideright = false;
        collidingWithPlatformsideleft = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        lamp_Rigidbody = GetComponent<Rigidbody>();
        //Light off, no battery yet
        lighton = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(lamp_Rigidbody.velocity.x == 0f) ---- BRAUCHEN WIR DAS NOCH?
        {
            lamp_Rigidbody.
        }*/
    }

    private void FixedUpdate()
    {
        //WALKING RIGHT - KEY D
        if (Input.GetKey(KeyCode.D) && lamp_Rigidbody.velocity.x < max_velocity_side && !collidingWithRight && !collidingWithPlatformsideright)
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            lamp_Rigidbody.AddForce(transform.right * side_Thrust);
        }

        //WALKING LEFT - KEY A
        if (Input.GetKey(KeyCode.A) && lamp_Rigidbody.velocity.x > -max_velocity_side && !collidingWithLeft && !collidingWithPlatformsideleft)
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            lamp_Rigidbody.AddForce(-transform.right * side_Thrust);
        }

        //JUMPING UP - SPACE BAR
        if (Input.GetKey(KeyCode.Space) && lamp_Rigidbody.velocity.y < max_velocity_jump && lamp_Rigidbody.velocity.y > -max_velocity_jump)
        {
            //transform.position += Vector3.up * speed * Time.deltaTime *10;
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            lamp_Rigidbody.AddForce(transform.up * jump_Thrust);
        }
        if (transform.position.y < 0.4)
        {
            transform.position += Vector3.up*speed;
        }
    }
}