using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class Movement : MonoBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;
    public int gridSize = 4;
    public float gridReselution = 1f;
    private bool collisionFront = true;
    private bool collisionBack = true;
    //public GameObject YourCar;
    //public Text myText;

    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance =
            mainCamera.WorldToScreenPoint(transform.position).z; //z axis of the game object for screen view

    }
    void OnMouseDrag()
    {
        Vector3 ScreenPosition =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); //z axis added to screen point 
        Vector3 NewWorldPosition =
            mainCamera.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point
        if (transform.localScale.y > transform.localScale.x)
        {

            NewWorldPosition.y = gridPos(NewWorldPosition.y);

            if (collisionFront && NewWorldPosition.y > transform.position.y)
                NewWorldPosition.y = transform.position.y;

            if (collisionBack && NewWorldPosition.y < transform.position.y)
                NewWorldPosition.y = transform.position.y;


            NewWorldPosition.x = transform.position.x;
        }
        else
        {
            NewWorldPosition.x = gridPos(NewWorldPosition.x);

            if (collisionFront && NewWorldPosition.x < transform.position.x)
                NewWorldPosition.x = transform.position.x;

            if (collisionBack && NewWorldPosition.x > transform.position.x)
                NewWorldPosition.x = transform.position.x;

            NewWorldPosition.y = transform.position.y;
        }

        transform.position = Vector3.MoveTowards(transform.position, NewWorldPosition, gridReselution/2);

        //Win(transform.position.y); //but just for YourCar?
    }

    float gridPos(float pos)
    {   
        if(pos <=0)
            return 0;

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
    //public void Win(float pos)
    //{   
        //if(pos <= 0)
        //{
            //myText.text = "You Won!";
            //Debug.Log("You Won!");
            //Console.WriteLine("You Won!");
        //}
        //GameObject i = Instantiate(YourCar) as GameObject;
        //if(i.transform.position.y <= 0)
        //{
            //Console.WriteLine("You Won!");
            //Debug.Log("You Won!");
        //}
    //}
}