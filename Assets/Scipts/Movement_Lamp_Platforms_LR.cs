using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Left-Right Movement of the Platforms of the Lampformer-Minigame

public class Movement_Lamp_Platforms_LR : MonoBehaviour
{
    //speed and max-/min-values can be changed in unity for each platform individually
    public float speed = 1.5f; 
    private bool moving_left = true; //variable to check whether platform is moving left
    public float min_pos_x = 5f;
    public float max_pos_x = 10f;

    public GameObject character;

    void Start()
    {
    }

    void Update()
    {
        if (moving_left) //moves platform to the left, as long it is in the defined range (min-max)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x < min_pos_x)
                moving_left = false;
        }
        else //moves platform to the right, as long it is in the defined range (min-max)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x > max_pos_x)
                moving_left = true;
        }
        
        
    }
    
}
