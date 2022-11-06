using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class color_ghost : MonoBehaviour
{
    // Start is called before the first frame update
    public Material blueGhost;
    public Material greenGhost;
    public Light ShouldGreen;
    private bool lighton;
    //public float counter = 0.5f;
    bool colorCheck;

    void Start()
    {
        colorCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldGreen.intensity > 1.0f)
        {
            lighton = true;
        }
        else
        {
            lighton = false;
        }
        //counter += Time.deltaTime;
        if (lighton == true)
        {
            if (colorCheck == false) //ghost turns blue when we reach battery
            {
                this.GetComponent<Renderer>().material = blueGhost; //new Color
                colorCheck = true;
                Debug.Log("blue");
            }
            /*else //ghost stays green as long as we didn't reach battery
            {
                this.GetComponent<Renderer>().material = greenGhost; //old Color
                colorCheck = false;
                Debug.Log("green");
            }*/
        }
        //Debug.Log(counter.ToString() + colorCheck.ToString());
    }
}
