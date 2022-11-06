using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Up-Down Movement of the Platforms of the Lampformer-Minigame

public class Movement_Lamp_Platforms_UD : MonoBehaviour
{
    //speed and max-/min-values can be changed in unity for each platform individually
    public float speed = 1.5f;
    private bool moving_up = true;
    public float min_pos_y = 5f;
    public float max_pos_y = 10f;

    public GameObject character;

    void Start()
    {
    }

    void Update()
    {
        if (moving_up) //moves platform up, as long it is in the defined range (min-max)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y > max_pos_y)
                moving_up = false;
        }
        else //moves platform down, as long it is in the defined range (min-max)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y < min_pos_y)
                moving_up = true;
        }


    }

}
