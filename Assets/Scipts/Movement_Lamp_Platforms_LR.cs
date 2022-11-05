using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Left-Right Movement of Platforms

public class Movement_Lamp_Platforms_LR : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 2.0f;
    private bool moving_left = true;
    public float min_pos_x = 5f;
    public float max_pos_x = 10f;

    public GameObject character;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (moving_left)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x < min_pos_x)
                moving_left = false;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x > max_pos_x)
                moving_left = true;
        }
        
        
    }
    
}
