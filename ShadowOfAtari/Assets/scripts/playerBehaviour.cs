using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 enum playerState { idle,falling,Grounded, climbing, overhangClimbing };

public class playerBehaviour : MonoBehaviour
{
    public float walkingSpeed, climbingSpeed;
    public string DebugState;


    playerState state;
    private Rigidbody2D Rbody;
    public float Grip;
    int Lives;
    bool alive;


    // Use this for initialization
    void Start()
    {
        walkingSpeed = 3.0f;
        climbingSpeed = 2.0f;
           
        alive = true;
        Lives = 3;
        Grip = 100f;

        state = playerState.idle;//change to enum
        DebugState = "idle";
        Rbody = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (alive)
        {
            switch (state)
            {
                case playerState.Grounded:
                    {
                        Walking();
                        DebugState = "ground";
                        RecoverGrip(0.2f);

                        break;
                    }
                case playerState.climbing:
                    {
                        if (playerHasGrip())
                        {
                            DebugState = "climbing";
                            Climbing();
                            DecreaseStaminaOverTime(0.2f);
                        }
                        else
                        {
                            state = playerState.falling;
                        }
                        break;
                    }
                case playerState.overhangClimbing:
                    {
                        if (playerHasGrip())
                        {
                            DebugState = "climbing";
                            Climbing();
                            DecreaseStaminaOverTime(0.4f);// more arm stress
                        }
                        else
                        {
                            state = playerState.falling;
                        }
                        break;
                    }
                case playerState.falling:
                    {
                        DebugState = "falling";
                        Rbody.gravityScale = 1;
                        RecoverGrip(0.2f);
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

    }

    void Walking()
    {
        Rbody.gravityScale = 1;
        Vector3 walk = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        this.transform.position += walk * walkingSpeed * Time.deltaTime;
    }

    void Climbing()
    {
        Rbody.gravityScale = 0;
        Vector3 climb = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        this.transform.position += climb * climbingSpeed * Time.deltaTime;

       
    }

    void DecreaseStaminaOverTime(float gripLossRate)
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



    private void OnTriggerStay2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "ground":
                state = playerState.Grounded;
                break;
            case "monstor":
                {
                    //if player action button
                    if (playerHasGrip())
                    {
                        if (Input.GetKey(KeyCode.Z)) // need to change for controller
                        {

                            state = playerState.climbing;
                            //if bottom of player is not colliding with monstor then 
                            /*{
                                action = playerState.overhangclimbing
                            }*/
                        }
                    }
                    break;
                }
            default:
                {
                   // state = playerState.falling;
                    break;
                }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "monstor")
        state = playerState.falling;
    }
}
