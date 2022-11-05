using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Left-Right Movement of Platforms

public class Movement_Lamp_Platforms_UD : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 2.0f;
    private bool moving_up = true;
    public float min_pos_y = 5f;
    public float max_pos_y = 10f;

    public GameObject character;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (moving_up)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y > max_pos_y)
                moving_up = false;
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y < min_pos_y)
                moving_up = true;
        }


    }

}
