using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum playerState { idle, falling, Grounded, climbing, overhangClimbing, dead };

public class playerBehaviour : MonoBehaviour
{
    public BossBehaviour boss;
    public float walkingSpeed, climbingSpeed, fallForce;
    public string DebugState;
    public bool FacingRight;
    public bool climbing = false;
    public int health;

    public Slider health_bar;
    public Slider grip_bar;

    public bool canClimb = false;
    private int collisionCount = 0;

    playerState state;
    private Rigidbody2D Rbody;
    private SpriteRenderer sprite;
    private Animator anim;
    public float Grip;
    int Lives;

    public float fireDelta = 0.3F;
    private float time = 0.0F;
    private float nextFire = 0.3F;


    // Use this for initialization
    void Start()
    {
        health = 100;
        health_bar.value = health;
        grip_bar.value = Grip;

        walkingSpeed = 3.0f;
        climbingSpeed = 2.0f;
        fallForce = 0.5f;

        Lives = 3;
        Grip = 100f;
        FacingRight = true;

        state = playerState.idle;//change to enum
        DebugState = "idle";
        Rbody = this.GetComponent<Rigidbody2D>();
        sprite = this.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        time = time + Time.deltaTime;

        health_bar.value = health;
        grip_bar.value = Grip;

        //if player action button
        if (canClimb)
        {
            if (Input.GetButton("Fire1") && time > nextFire)
            {
                nextFire = time + fireDelta;
                if (playerHasGrip())
                {
                    switch (climbing)
                    {
                        case true:
                            state = playerState.falling;

                            Debug.Log("Falling state");
                            break;

                        case false:

                            state = playerState.climbing;

                            Debug.Log("climbingState");
                            break;

                        default:
                            break;
                    }
                }
                nextFire = nextFire - time;
                time = 0.0F;
            }
        }
    }

    private bool playerHasGrip()
    {
        if (Grip <= 0)
        {
            return false;
        }
        return true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grip_bar.value = Grip;
        switch (state)
        {
            case playerState.Grounded:
                {
                    //setNewSprite("walking1");
                    Walking();
                    DebugState = "ground";
                    RecoverGrip(0.2f);
                    break;
                }
            case playerState.climbing:
                {
                    //if boss is shaking then grip will drain faster.
                    if (boss.state == BossBehaviour.boss_states.SHAKING)
                    {
                        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                        {
                            DebugState = "climbing";
                            Climbing();
                            DecreaseGripOverTime(10.0f);
                        }
                        //setNewSprite("climbing1");
                    }

                    else if (playerHasGrip())
                    {
                        climbing = true;
                        DebugState = "climbing";
                        Climbing();
                        DecreaseGripOverTime(0.2f);

                    }
                    else
                    {
                        state = playerState.falling;
                        climbing = false;
                    }
                    break;
                }
            case playerState.falling:
                {
                    // setNewSprite("walking1");
                    anim.SetBool("Climbing", false);
                    DebugState = "falling";
                    Falling();
                    RecoverGrip(0.2f);
                    climbing = false;
                    break;
                }
            case playerState.dead:
                {

                    break;
                }
            // add faling movement same as wallking but no annimation
            default:
                {
                    // setNewSprite("walking1");
                    RecoverGrip(0.2f);
                    break;
                }
        }
    }

    

    void setNewSprite(string spriteName)
    {
        if (sprite.sprite.name != spriteName)
        {
            sprite.sprite = Resources.Load(spriteName, typeof(Sprite)) as Sprite;
        }
    }

    void Walking()
    {
        Rbody.gravityScale = 1;
        anim.SetBool("Climbing", false);
        Vector3 walk = Vector3.zero;
        float h = Input.GetAxis("Horizontal");
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

        if (h != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
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
        Rbody.gravityScale = 0;
        anim.SetBool("Walking", false);
        Rbody.velocity = new Vector2(0, 0);

        Vector3 climb = Vector3.zero;
        climb = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        this.transform.position += climb * climbingSpeed * Time.deltaTime;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (state == playerState.climbing)
       {
            if ((h != 0) || (v != 0))
            {
                anim.SetBool("Climbing", true);
            }
            else
            {
                anim.SetBool("Climbing", true);
            }
        }
        

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
        Rbody.gravityScale = 1;
        float h = Input.GetAxis("Horizontal");
        Vector3 fall = new Vector3(h, 0, 0);
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
        if (Grip <= 0)
        {
            Grip = 0;
        }
        else
        {
            Grip -= gripLossRate * Time.deltaTime;
        }
    }

    void RecoverGrip(float recoverRate)
    {
        if (Grip <= 100)
        {
            Grip += recoverRate * Time.deltaTime;
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            state = playerState.Grounded;
        }
        if (other.tag == "monstor")
        {
            collisionCount++;
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButton("Fire2"))
        {
            if (other.tag == "weakSpot")
            {
                attackWeakSpot();
            }

        }
        if (other.tag == "monstor")
        {
            canClimb = true;

        }
        if (other.tag == "ground")
        {
            if (!climbing)
            {
                state = playerState.Grounded;
            }
        }
        //else
        //{
        //    canClimb = false;
        //}
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "monstor")
        {
            collisionCount--;
        }
        if (collisionCount == 0)
        {
            canClimb = false;

        }
        if (other.tag == "monstor" && !canClimb)
        {
            state = playerState.falling;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "arm")
        {
            state = playerState.falling;
        }
    }
}

