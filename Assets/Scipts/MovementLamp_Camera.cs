using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera following the player up / down (vertical scroll)

public class MovementLamp_Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Playertransformation;
    public GameObject character;
    private float startingoffset;
    void Start()
    {
        startingoffset = Playertransformation.position.y-transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up*((Playertransformation.position.y - startingoffset)-transform.position.y);
        
    }
}
