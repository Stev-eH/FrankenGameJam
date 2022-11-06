using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameLogic : MonoBehaviour
{
    public int loaded = 0;
    public bool labyrinthWin = false;
    public bool bunnyWin = false;
    public bool isActive = false;

    public GameObject ui;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("logic");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        ui.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        if (!isActive && Input.GetKeyDown(KeyCode.Q))
        {
            isActive = true;
            ui.GetComponent<Canvas>().enabled = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            Debug.Log("An");
        }
        else if (isActive && Input.GetKeyDown(KeyCode.Q))
        {
            isActive = false;
            ui.GetComponent<Canvas>().enabled = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Aus");
        }
    }
}
