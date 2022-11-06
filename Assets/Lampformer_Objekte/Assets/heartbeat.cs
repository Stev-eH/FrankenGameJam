using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartbeat : MonoBehaviour
{
    public Material newColor;
    public Material oldColor;
    public float counter= 0.5f;
    bool colorFlag;

    // Start is called before the first frame update
    void Start()
    {
        //Color color = Color.green;
        //oldColor = this.GetComponent<Renderer>().material;
        colorFlag=false;
    }

    // Update is called once per frame
    void Update()
    {
        // this.GetComponent<Renderer>().materials[0].SetColor("blau", Color.blue);
        //Debug.Log(this.GetComponent<Renderer>().materials[0].GetColor("blau"));
        //this.GetComponent<Renderer>().material = newColor;
        counter+=Time.deltaTime;
        if (counter >= 0.5)
        {
            if (colorFlag == false)
            {
                this.GetComponent<Renderer>().material = newColor;
                colorFlag = true;
                Debug.Log("color 1");
            }
            else
            {
                this.GetComponent<Renderer>().material = oldColor;
                colorFlag = false;
                Debug.Log("color 2");
            }
            counter = 0;
        }
        Debug.Log(counter.ToString()  +colorFlag.ToString());
    }
}
