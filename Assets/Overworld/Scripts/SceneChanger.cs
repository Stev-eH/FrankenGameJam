using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Interactable>().isHighlight)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject.FindGameObjectWithTag("logic").GetComponent<GameLogic>().loaded += 1;
                SceneManager.LoadScene(1);
            }
        }
    }
}
