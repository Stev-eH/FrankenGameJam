using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveIndianaJones : MonoBehaviour
{
    private Rigidbody rb;

    float horizontal;
    float vertical;

    private int xTreasur = 0;
    private int zTreasur = 0;
    private bool win = false;
    public float runSpeed = 15f;

    public GameObject myText;
    public GameObject startText;

    public cameraFollow playsound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myText.SetActive(false);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if ((transform.position.z + transform.position.x) != 0)
            startText.SetActive(false);


        if (Mathf.Round(transform.position.z) == zTreasur && Mathf.Round(transform.position.x) == xTreasur && !win)
        {

            Debug.Log("WIN");
            myText.SetActive(true);
            playsound.winSound();
            GameObject.FindGameObjectWithTag("logic").GetComponent<GameLogic>().labyrinthWin = true;
            SceneManager.LoadScene(0);
            win = true;

        }
    }
  
    private void FixedUpdate()
    {   
        Vector3 movement = new Vector3(horizontal * runSpeed, 0.0f, vertical * runSpeed);
        rb.velocity = movement;
        if (!(movement.x == 0f && movement.z == 0f))
            transform.rotation = Quaternion.LookRotation(movement);
    }


    public void treasurHint(int x ,int z)
    {
        xTreasur = x;
        zTreasur = z;
        Debug.Log("Treusur: X:" + x + " Z: " + z);
    }
}
