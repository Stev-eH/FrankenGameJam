using System;
using UnityEngine;

public class BunnyControl : MonoBehaviour
{
    public bool colliding = false; // variable to check whether object is colliding

    //public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);

    Rigidbody lamp_Rigidbody;
    public float speed = 0.1f;
    public GameObject character;
    public float side_Thrust = 10f;
    public float jump_Thrust = 300f;
    public float max_velocity_side = 2f;
    public float max_velocity_jump = 0.001f;

    

    

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
        if (Input.GetKey(KeyCode.D) && lamp_Rigidbody.velocity.x < max_velocity_side )
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            lamp_Rigidbody.AddForce(transform.right * side_Thrust);
        }
        if (Input.GetKey(KeyCode.A) && lamp_Rigidbody.velocity.x > -max_velocity_side)
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
      
    }
}