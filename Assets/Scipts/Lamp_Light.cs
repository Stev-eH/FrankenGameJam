using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp_Light : MonoBehaviour
{
    public float lightintensity = 3f;
    Light myLight;


    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void lamponfunc(bool lampon2){
        if(!lampon2){
            myLight.intensity = 0f;
            }
        else{
            myLight.intensity = lightintensity;
        }
    }
}
