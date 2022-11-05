using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Left-Right Movement of Platforms

public class Movement_Ghost : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed_x = 0.7f;
    public float speed_y = 0.7f;
    public float speed_min = 0.2f;
    public float speed_max = 0.9f;
    private bool moving_left = true;
    private bool moving_up = true;
    public float min_pos_x = -2f;
    public float max_pos_x = 8.5f;
    public float min_pos_y = -4f;
    public float max_pos_y = 3.5f;

    public GameObject character;

    void Start()
    {
        speed_x=Random.value*(speed_max-speed_min)+speed_min;
        speed_y=Random.value *(speed_max - speed_min)+speed_min;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed_x * Time.deltaTime;
        transform.position += Vector3.up * speed_y * Time.deltaTime;
        if (transform.position.x < min_pos_x )
        {
            speed_x = Random.value * (speed_max - speed_min) + speed_min;
        }
        if (transform.position.x > max_pos_x )
        {
            speed_x = -(Random.value * (speed_max - speed_min) + speed_min);
        }
        if (transform.position.y < min_pos_y )
        {
            speed_y = Random.value * (speed_max - speed_min) + speed_min;
        }
        if (transform.position.y > max_pos_y )
        {
            speed_y = -(Random.value * (speed_max - speed_min) + speed_min);
        }





    }

}
