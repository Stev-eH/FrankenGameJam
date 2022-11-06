using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(Collider))]
public class Movement : MonoBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;
    public bool goldenCar = false;
    public float gridReselution = 1f;
    private bool collisionFront = true;
    private bool collisionBack = true;
    public GameObject myText;
    public bool CarWin = false;

    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z; //z axis of the game object for screen view
        myText.SetActive(false);

        

    }
    void OnMouseDrag()
    {   //Position der Maus auf dem Bildschirm in Pixeln
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); 

        //Mausposition in Unity Koordinatenumrechen
        Vector3 NewWorldPosition = mainCamera.ScreenToWorldPoint(ScreenPosition); 


        if (transform.localScale.y > transform.localScale.x)
        {
            NewWorldPosition.y = gridPos(NewWorldPosition.y - transform.localScale.y / 2) + transform.localScale.y / 2;
            if (collisionFront && NewWorldPosition.y > transform.position.y)
                NewWorldPosition.y = transform.position.y;

            if (collisionBack && NewWorldPosition.y < transform.position.y)
                NewWorldPosition.y = transform.position.y;

            NewWorldPosition.x = transform.position.x;
        }
        else
        {
            NewWorldPosition.x = gridPos(NewWorldPosition.x - transform.localScale.x / 2) + transform.localScale.x/2;

            if (collisionFront && NewWorldPosition.x < transform.position.x)
                NewWorldPosition.x = transform.position.x ;

            if (collisionBack && NewWorldPosition.x > transform.position.x)
                NewWorldPosition.x = transform.position.x;

            NewWorldPosition.y = transform.position.y;
        }

        transform.position = Vector3.MoveTowards(transform.position, NewWorldPosition, gridReselution);
        
        //Siegerehrung
        if(goldenCar && transform.position.y <= 0)
        { 
            myText.SetActive(true);
            //GameObject.FindGameObjectWithTag("logic").GetComponent<GameLogic>().CarWin = true;
            //SceneManager.LoadScene(0);
        }
          
    }

    float gridPos(float pos)
    {       
        float posistion = Mathf.Round(pos / gridReselution) * gridReselution;
        return posistion;
    }

    public void CollisionDetectedFront()
    {
        collisionFront = !collisionFront;
        Debug.Log("collisionFront: " + collisionFront);
    }

    public void CollisionDetectedBack()
    {
        collisionBack = !collisionBack;
        Debug.Log("collisionBack: " + collisionBack);
    }
}