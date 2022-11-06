using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLaby : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("logic");
        if (obj.GetComponent<GameLogic>().labyrinthWin)
        {
            this.GetComponent<Light>().enabled = true;
        }
    }
}
