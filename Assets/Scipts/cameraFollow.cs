using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public static AudioClip clip;
    public AudioSource source;
    private bool win = false;
    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }

    private void Start()
    {
        
    }

    public void winSound()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }
}
