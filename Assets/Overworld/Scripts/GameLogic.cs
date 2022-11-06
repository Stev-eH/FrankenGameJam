using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public int loaded = 0;
    public bool labyrinthWin = false;
    public bool bunnyWin = false;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("logic");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        Debug.Log(loaded);
    }
}
