using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum playerState { idle, falling, grounded, climbing, dead };

public class playerBehaviour : MonoBehaviour
{
    public float walkingSpeed, climbingSpeed, fallForce;
    public string DebugState;
    public bool FacingRight;
    public bool climbing;

    playerState state;
    private Rigidbody2D Rbody;
    //private SpriteRenderer sprite;
    public float Grip;


    // Use this for initialization
    void Start()
    {
        FacingRight = true;
        walkingSpeed = 3.0f;

        fallForce = 0.5f;

        climbingSpeed = 2.0f;
        climbing = false;
        Grip = 100f;
       
        state = playerState.idle;//change to enum
        DebugState = "idle";

        Rbody = this.GetComponent<Rigidbody2D>();
        //sprite = this.GetComponent<SpriteRenderer>();

        Rbody.gravityScale = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case playerState.grounded:
                {
                    DebugState = "ground";
                    climbing = false;
                    Rbody.gravityScale = 1;
                    Walking();
                    RecoverGrip(0.2f);
                    break;
                }

            case playerState.climbing:
                {
                    Rbody.gravityScale = 0;
                    climbing = true;
                    if (playerHasGrip())
                    {
                        Climbing();
                        DecreaseGripOverTime(0.2f);
                    }
                    else
                    {
                        state = playerState.falling;
                    }
                    break;
                }
            case playerState.falling:
                {
                    climbing = false;
                    DebugState = "falling";
                    Rbody.gravityScale = 1;
                    Falling();
                    RecoverGrip(0.2f);
                    break;
                }
            case playerState.dead:
                {
                    break;
                }
            // add faling movement same as wallking but no annimation
            default:
                {
                    RecoverGrip(0.2f);
                    break;
                }
        }
    }

    void Walking()
    {
        Vector3 walk = Vector3.zero;
        float h = 0;
        h = Input.GetAxis("Horizontal");
        walk = new Vector3(h, 0, 0);
        this.transform.position += walk * walkingSpeed * Time.deltaTime;

        if (h > 0 && !FacingRight)
        {
            Flip();
        }
        else if (h < 0 && FacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Climbing()
    {
        Vector3 climb = Vector3.zero;
        float h = 0, v = 0; ;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        climb = new Vector3(h , v, 0);
        this.transform.position += climb * climbingSpeed * Time.deltaTime;
    }

    void attackWeakSpot()
    {
        //get object refrence
        // deal damage 
        // tell boss to trun off weak spot effect 

        //get monstor element
        // minus damge from monstors health 
        // set health(get health - player attack)
    }


    void Falling()
    {
        Vector3 fall = Vector3.zero;
        float h = 0;
        h = Input.GetAxis("Horizontal");
        fall = new Vector3(h, 0, 0);
        this.transform.position += fall * fallForce * Time.deltaTime;

        if (h > 0 && !FacingRight)
        {
            Flip();
        }
        else if (h < 0 && FacingRight)
        {
            Flip();
        }
    }

    void DecreaseGripOverTime(float gripLossRate)
    {
        Grip -= gripLossRate * Time.deltaTime;
    }

    void RecoverGrip(float recoverRate)
    {
        if (Grip <= 100)
        {
            Grip += recoverRate * Time.deltaTime;
        }
    }

    bool playerHasGrip()
    {
        if (Grip <= 0)
        {
            return false;
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            state = playerState.grounded;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        //if (other.tag == "weakSpot")
        //{
        //    if (Input.GetButton("Fire2"))
        //    {
        //        attackWeakSpot();
        //    }

        //}
        //else 
        if (other.tag == "monstor")
        {
            if (playerHasGrip())
            {
                if (Input.GetButtonUp("Fire1"))
                {
                    switch (climbing)
                     {
                         case true:
                             state = playerState.falling;
                                Debug.Log("falling");
                             break;

                         case false:

                             state = playerState.climbing;

                             break;

                         default:
                             break;
                     }

                }
                
            }
        }
    }
    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "monstor")
        {
             state = playerState.falling;
        }
    }*/
}
