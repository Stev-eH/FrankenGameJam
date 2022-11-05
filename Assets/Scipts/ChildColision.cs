using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColision : MonoBehaviour
{   
    public bool side = true;
    void OnCollisionEnter(Collision collision)
    {
        if(side)
            transform.parent.GetComponent<Movement>().CollisionDetectedFront();
        else
            transform.parent.GetComponent<Movement>().CollisionDetectedBack();
    }

    void OnCollisionExit(Collision collision)
    {
        if (side)
            transform.parent.GetComponent<Movement>().CollisionDetectedFront();
        else
            transform.parent.GetComponent<Movement>().CollisionDetectedBack();
    }
}
