using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int index;

    /*
     * Zum Szenenwechsel
     * Dieses Script anhängen und Interactable.cs anhängen
     * Interactable: Als Material Glow auswählen evtl. Größe einstellen
     * SceneChanger: passenden Index auswählen

    /* Index
     * 0 : Zimmer
     * 1 - 5: Autoteppich Level 1 - 5 
     * 6: Erich-Vivi
     * 7: Heidi-Emily
     * 8: Labyrinth
     */

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
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                GameObject.FindGameObjectWithTag("logic").GetComponent<GameLogic>().loaded += 1;
                SceneManager.LoadScene(index);
            }
        }
    }
}
