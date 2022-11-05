using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Update is called once per frame
     public float horizontalSpeed = 2.0F;
    private Vector3 playerVelocity;
    Rigidbody m_Rigidbody;
    float m_Speed;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 2.0f;
    }
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);

        if (Input.GetKey(KeyCode.W))
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = transform.forward * m_Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            m_Rigidbody.velocity = -transform.forward * m_Speed;
        }
    }
}
