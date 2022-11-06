using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Movement of Player in the Lampformer-Minigame

public class MoveLampFormer : MonoBehaviour
{
    public bool colliding = false; // variable to check whether lamp is colliding with other objects

    //public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);
    
    Rigidbody lamp_Rigidbody;
    public float speed = 0.1f;
    public GameObject character;
    public float side_Thrust = 10f; //force of horizontal movements (walking)
    public float jump_Thrust = 50f; //force of vertical movements (jumping)
    public float max_velocity_side = 2f; //max speed for horizontal movements
    public float max_velocity_jump = 0.01f; //max speed for vertical movements

    //Collision Flags & variables
    public string collidingObjectName = "none"; //Name of object player is colliding with
    private bool collidingWithLeft = false; //collision with frame
    private bool collidingWithRight = false; //collision with frame
    private bool collidingWithPlatformsideleft = false;
    private bool collidingWithPlatformsideright = false;
    private float startingoffsetx = 0; //Offset for Collision with moving platforms
    public bool lighton = false; //checks whether light of Player-Lamp is on
    //public Lamp_Light lighton2;
    public Light Lamp;
    public Light Generallighting;

    //Lost/Won
    private bool lost=false;
    private bool won=false;
    private float timetillrestart= 1.0f;
    private float timeafterwon=5.0f;

    //Audio
    //public AudioSource Source;
    public AudioSource WinSound;
    public AudioSource LooseSound;//Game_Over4
    public AudioSource JumpSound;//Jump2
    public AudioSource GotBatterySound;//Winning1

    private void OnCollisionStay(Collision col) //actions while Player is colliding with other objects
    {
        //checks whether Player is standing on a moving platform, and makes Player move along
        if (col.gameObject.transform.parent.name == "Dynamic_Platform" && col.gameObject.transform.position.y > transform.position.y - 0.41f)
        {
            //Debug.Log("huhu");
            transform.position += Vector3.right*((col.gameObject.transform.position.x - startingoffsetx) -transform.position.x);
        }
    }

    void OnCollisionEnter(Collision col) //actions when Player is colliding with other objects
    {
        colliding = true;
        
        //checks what player is colliding with
        if (col.gameObject.name == "Platform_Right") //Right Side of the Frame
        {
            collidingWithRight = true;
        }
        else if(col.gameObject.name == "Platform_Left") //Right Side of the Frame
        {
            collidingWithLeft = true;
        }
        else if(col.gameObject.name == "Battery") //Reached the Battery
        {
            //Collected battery
            lighton = true;
            GotBatterySound.Play();
            
        }
        else if(col.gameObject.transform.parent.name == "Enemy") //Hit an enemy
        {
            //hit ghost
            if (lighton)
            {
                //Won
                Generallighting.intensity=2f;
                won=true;
                WinSound.Play();
                
            }
            else
            {
                //Lost, Restart
                Generallighting.intensity=0.1f;
                lost=true;
                LooseSound.Play();
                
            }

        }
        else if (col.gameObject.transform.position.y>transform.position.y-0.4f) //Player hit platform from the side
        {
            if (col.gameObject.transform.position.x < transform.position.x)
            {
                collidingWithPlatformsideleft = true;
            }
            else
            {
                collidingWithPlatformsideright = true;
            }
            
        };

        if (col.gameObject.transform.parent.name == "Dynamic_Platform" && col.gameObject.transform.position.y > transform.position.y - 0.41f)
        {
            //Collision with left-right moving platform, standing on it
            startingoffsetx = col.gameObject.transform.position.x - transform.position.x;

        }
    }

    void OnCollisionExit (Collision col) //actions when Player is done colliding with other objects
    {
        //reset of all collision flags
        if (col.gameObject.name == "Platform_Right")
        {
            collidingWithRight = false;
        }
        else if (col.gameObject.name == "Platform_Left")
        {
            collidingWithLeft = false;
        };
        collidingWithPlatformsideright = false;
        collidingWithPlatformsideleft = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        lamp_Rigidbody = GetComponent<Rigidbody>();
        //Light off, no battery yet
        lighton = false;
        Lamp.intensity = 0f;
        Generallighting.intensity = 0.5f;
        WinSound = GameObject.Find("lamp_Ghost").GetComponent<AudioSource>();
        LooseSound = GameObject.Find("Platform_Ground").GetComponent<AudioSource>();//Game_Over4
        JumpSound = GetComponent<AudioSource>();//Jump2
        GotBatterySound= GameObject.Find("Battery").GetComponent<AudioSource>();
        WinSound.Stop();
        LooseSound.Stop();
        JumpSound.Stop();
        GotBatterySound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(lamp_Rigidbody.velocity.x == 0f) ---- BRAUCHEN WIR DAS NOCH? NEIN.
        {
            lamp_Rigidbody.
        }*/
        if(lighton){
            Lamp.intensity = 2f;
        }
        else{
            Lamp.intensity = 0f;
        }
        if(won ||lost){
            if(lost){
                timetillrestart -= Time.deltaTime;
            }
            else{
                timeafterwon -= Time.deltaTime;
            }
            
            if((timetillrestart<=0 && lost)||(timeafterwon<=0 && won)){
                Generallighting.intensity = 0.5f;
                WinSound.Stop();
                LooseSound.Stop();
                JumpSound.Stop();
                GotBatterySound.Stop();
                if(won){
                    //Win condition, exit game
                    lighton = true;
                    GameObject.FindGameObjectWithTag("logic").GetComponent<GameLogic>().lampWin= true;
                    SceneManager.LoadScene(0);
                }
                else{
                    //Loose condition, restart game
                    lighton = false;
                    lost = false;
                    won = false;
                    Scene scene = SceneManager.GetActiveScene(); 
                    SceneManager.LoadScene(scene.name);
                }
            }
        }
       
    }

    private void FixedUpdate()
    {
        //WALKING RIGHT - KEY D
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && lamp_Rigidbody.velocity.x < max_velocity_side && !collidingWithRight && !collidingWithPlatformsideright)
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            lamp_Rigidbody.AddForce(transform.right * side_Thrust);
        }

        //WALKING LEFT - KEY A
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && lamp_Rigidbody.velocity.x > -max_velocity_side && !collidingWithLeft && !collidingWithPlatformsideleft)
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            lamp_Rigidbody.AddForce(-transform.right * side_Thrust);
        }

        //JUMPING UP - SPACE BAR
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && lamp_Rigidbody.velocity.y < max_velocity_jump && lamp_Rigidbody.velocity.y > -max_velocity_jump)
        {
            //transform.position += Vector3.up * speed * Time.deltaTime *10;
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            lamp_Rigidbody.AddForce(transform.up * jump_Thrust);
            JumpSound.Play();
        }
        if (lamp_Rigidbody.velocity.y <(-5f))
        {
            lamp_Rigidbody.AddForce(transform.up *jump_Thrust/5);
        }
    }
    //public void lamponfunc(bool lampon2);
}