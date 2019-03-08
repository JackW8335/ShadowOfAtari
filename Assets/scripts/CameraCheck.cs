using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCheck : MonoBehaviour
{

    private Camera thisCam;
    private BoxCollider2D trigger;

    private bool enableCam = false;
    //Enable this if its the first cam
    public bool startingCam = false;

    private void Start()
    {
        thisCam = GetComponent<Camera>();
        trigger = GetComponent<BoxCollider2D>();
        if (!startingCam)
        {
            thisCam.enabled = false;
            float height = 2f * thisCam.orthographicSize;
            float width = height * thisCam.aspect;

            trigger.size = new Vector2(width, height);
        }
       else
        {
            enableCam = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if(enableCam)
        {
            thisCam.enabled = true;
            
        }
        else
        {
            thisCam.enabled = false;
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enableCam = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enableCam = false;
        }
    }
}
