using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Movement : MonoBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;
    public int gridSize = 4;
    public float gridReselution = 1.5f;

    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance =
            mainCamera.WorldToScreenPoint(transform.position).z; //z axis of the game object for screen view
    }

    private float counter = 0;

    void OnMouseDrag()
    {
        Vector3 ScreenPosition =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); //z axis added to screen point 
        Vector3 NewWorldPosition =
            mainCamera.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point
        if (transform.localScale.z > transform.localScale.x)
        {
            NewWorldPosition.z = gridPos(NewWorldPosition.z);
            NewWorldPosition.x = transform.position.x;
        }
        else
        {
            NewWorldPosition.x = gridPos(NewWorldPosition.x);
            NewWorldPosition.z = transform.position.z;
        }
        transform.position = NewWorldPosition;
    }

    float gridPos(float pos)
    {
        Debug.Log(pos);
        if (pos < 0)
            return 0;

        if (pos / gridReselution >= gridSize)
            return gridReselution * gridSize;

        float posistion = Mathf.Round(pos / gridReselution) * gridReselution;
        Debug.Log(posistion);
        return posistion;
    }


}