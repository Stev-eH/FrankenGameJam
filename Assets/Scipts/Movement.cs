using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Movement : MonoBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;
    public int gridSize = 4;
    public float gridReselution = 1f;
    private bool collisionFront = true;
    private bool collisionBack = true;

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
            NewWorldPosition.y = gridPos(NewWorldPosition.y + (transform.localScale.y / 2));
            NewWorldPosition.x = transform.position.x;
        }
        else
        {
            NewWorldPosition.x = gridPos(NewWorldPosition.x + (transform.localScale.x / 2));
            NewWorldPosition.y = transform.position.y;
        }

        transform.position = NewWorldPosition;
    }

    float gridPos(float pos)
    {
        if (pos < 0)
            return 0;

        if (pos / gridReselution >= gridSize)
            return gridReselution * gridSize;

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