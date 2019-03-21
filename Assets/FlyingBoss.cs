using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlyingBoss : BossBehaviour
{

    private Vector3 startingPos;
    private Vector3 swoopPos;

    private float lerpSpeed = 0.3f;
    private float swoopTime = 0f;

    private Animator[] wingAnims;

    bool swoopDown = true;
    bool playerOnBoard = false;

    // Use this for initialization
     protected override void Start ()
    {
        base.Start();
        startingPos = transform.position;
        swoopPos = new Vector3(startingPos.x, startingPos.y - 15, startingPos.z);
        wingAnims = new Animator[2];

        for(int i = 0; i < 2; i++)
        {
            wingAnims[i] = transform.GetChild(i).GetComponent<Animator>();
        }
    }
	
	// Update is called once per frame
	protected override void Update ()
    {
        if (health <= 0.0f)
        {
            state = BOSS_STATES.DEAD;
            SceneManager.LoadScene(levelToLoad);
        }

        time += Time.deltaTime;

        if (!playerOnBoard)
        {
            if (Time.time - swoopTime >= Random.Range(5, 20) &&
                state != BOSS_STATES.SWOOPING)
            {
                state = BOSS_STATES.SWOOPING;
                swoopTime = Time.time;
            }

            if (state == BOSS_STATES.SWOOPING)
            {
                Swoop();
            }
        }
    }

    private void Swoop()
    {
        if(swoopDown)
        {
            for(int i = 0; i < 2; i++)
            {
                wingAnims[i].SetTrigger("LowerWing");
            }

            transform.position = Vector3.Lerp(transform.position, swoopPos, lerpSpeed * Time.deltaTime);
            if (transform.position.y <= (swoopPos.y + 5))
            {
                swoopDown = false;
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                wingAnims[i].SetTrigger("WingUp");
            }
            transform.position = Vector3.Lerp(transform.position, startingPos, lerpSpeed * Time.deltaTime);
            if(transform.position.y >= (startingPos.y - 2 ))
            {
                state = BOSS_STATES.NORMAL;
                swoopDown = true;
                swoopTime = Time.time;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerOnBoard = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerOnBoard = false;
        }
    }

}
