using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float verticalSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(-v, 0, 0);
        if (transform.eulerAngles.x >= 90f)
        {
            transform.eulerAngles = new Vector3(0f, Quaternion.identity.eulerAngles.y, Quaternion.identity.eulerAngles.z);
        }
        else if (transform.eulerAngles.x >= 125f)
        {
            transform.eulerAngles = new Vector3(125f, Quaternion.identity.eulerAngles.y, Quaternion.identity.eulerAngles.z);
        }
    }
}
