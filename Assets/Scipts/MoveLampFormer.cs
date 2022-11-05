using System;
using UnityEngine;

public class MoveLampFormer : MonoBehaviour
{
    public bool colliding = false; // variable to check whether object is colliding

    //public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);

    Rigidbody lamp_Rigidbody;
    public float speed = 0.1f;
    public GameObject character;
    public float side_Thrust = 10f;
    public float jump_Thrust = 50f;
    public float max_velocity_side = 2f;
    public float max_velocity_jump = 0.01f;
    public string collidingObjectName = "none";
    private bool collidingWithLeft = false;
    private bool collidingWithRight = false;
    private bool collidingWithPlatformsideleft = false;
    private bool collidingWithPlatformsideright = false;
    public float startingoffsetx = 0;

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.transform.parent.name == "Dynamic_Platform" && !collidingWithPlatformsideleft && !collidingWithPlatformsideright)
        {
            //Debug.Log("huhu");
            transform.position += Vector3.right*((col.gameObject.transform.position.x - startingoffsetx) -transform.position.x);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        colliding = true;
        
        if (col.gameObject.name == "Platform_Right")
        {
            collidingWithRight = true;
        }
        else if(col.gameObject.name == "Platform_Left")
        {
            collidingWithLeft = true;
        }
        else if (col.gameObject.transform.position.y>transform.position.y-0.39f)
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
        if (col.gameObject.transform.parent.name == "Dynamic_Platform" && !collidingWithPlatformsideleft && !collidingWithPlatformsideright)
        {
            //Collision with left-right moving platform, standing on it
            startingoffsetx = col.gameObject.transform.position.x - transform.position.x;

        }
    }

    void OnCollisionExit (Collision col)
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        /*if(lamp_Rigidbody.velocity.x == 0f)
        {
            lamp_Rigidbody.
        }*/
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) && lamp_Rigidbody.velocity.x < max_velocity_side && !collidingWithRight && !collidingWithPlatformsideright)
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            lamp_Rigidbody.AddForce(transform.right * side_Thrust);
        }
        if (Input.GetKey(KeyCode.A) && lamp_Rigidbody.velocity.x > -max_velocity_side && !collidingWithLeft && !collidingWithPlatformsideleft)
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            lamp_Rigidbody.AddForce(-transform.right * side_Thrust);
        }
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