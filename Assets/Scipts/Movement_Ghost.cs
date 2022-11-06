using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Movement of the Ghosts in the Lampformer Game

public class Movement_Ghost : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed_x = 0.7f; //speed of movement in x-direction
    public float speed_y = 0.7f; //speed of movement in y-direction

    //range speed
    public float speed_min = 0.2f;
    public float speed_max = 0.9f;

    private bool moving_left = true; //variable to check whether ghost is moving to the left
    private bool moving_up = true; //variable to check whether ghost is moving up

    //range movement (x-axis & y-axis)
    public float min_pos_x = -2f; 
    public float max_pos_x = 8.5f;
    public float min_pos_y = -4f;
    public float max_pos_y = 3.5f;

    public GameObject character;

    void Start()
    {
        //generate random values to initialize speed in both direction
        speed_x=Random.value*(speed_max-speed_min)+speed_min;
        speed_y=Random.value *(speed_max - speed_min)+speed_min;
    }

    // Update is called once per frame
    void Update()
    {
        //changes position of ghost
        transform.position += Vector3.right * speed_x * Time.deltaTime;
        transform.position += Vector3.up * speed_y * Time.deltaTime;

        //checks whether ghost reached side of frame and generates a new random speed
        if (transform.position.x < min_pos_x ) // left side of frame
        {
            speed_x = Random.value * (speed_max - speed_min) + speed_min;
        }
        if (transform.position.x > max_pos_x ) // right side of frame
        {
            speed_x = -(Random.value * (speed_max - speed_min) + speed_min);
        }
        if (transform.position.y < min_pos_y ) // lower side of frame
        {
            speed_y = Random.value * (speed_max - speed_min) + speed_min;
        }
        if (transform.position.y > max_pos_y ) // upper side of frame
        {
            speed_y = -(Random.value * (speed_max - speed_min) + speed_min);
        }





    }

}
