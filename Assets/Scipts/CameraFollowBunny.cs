using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class CameraFollowBunny : MonoBehaviour
{
    Transform CamTransform;
    public Transform Player;



    // Start is called before the first frame update
    void Start()
    {
        CamTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CamTransform.position = new Vector3(Player.position.x, CamTransform.position.y, CamTransform.position.z);
    }
}
