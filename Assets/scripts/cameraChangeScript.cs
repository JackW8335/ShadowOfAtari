﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChangeScript : MonoBehaviour {

    public Camera oldCamera;
    public Camera newCamera;
    private Camera oldCameraSave;
    private Camera newCameraSave;
    public GameObject player;
    private bool enterFromLeft;
    private bool enterFromAbove;

    private void Start()
    {
        newCamera.enabled = false;  //disable all but start camera at beginning
        enterFromLeft = false;
    }

    void Update()
    {
        //Try camera system working this way so the update keeps it in the right position, remove the teleportation etc
        //switch (player.GetComponent<playerBehaviour>().playerPosition)
        //{
        //    case PlayerPosition.START:
                
        //        break;
        //    case PlayerPosition.BOTTOM_CAMERA:
        //        newCamera = GameObject.Find("Camera_1").GetComponent<Camera>();
        //        newCamera.enabled = true;
        //        oldCamera.enabled = false;
        //        break;
        //    case PlayerPosition.MIDDLE_CAMERA:
        //        newCamera = GameObject.Find("Camera_2").GetComponent<Camera>();
        //        newCamera.enabled = true;
        //        oldCamera.enabled = false;
        //        break;
        //    case PlayerPosition.TOP_CAMERA:
        //        newCamera = GameObject.Find("Camera_3").GetComponent<Camera>();
        //        newCamera.enabled = true;
        //        oldCamera.enabled = false;
        //        break;
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Enter");
            oldCameraSave = oldCamera;  //save which cameras were old and new
            newCameraSave = newCamera;
            newCamera.enabled = true;   //disable old camera and enable new
            oldCamera.enabled = false;
        }

        positionBasedOnCamera(other);
        //Debug.Log(enterFromLeft + " " + this.gameObject.name.ToString());
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Leaving");
            oldCamera = newCameraSave;  //swap active cameras using old saves
            newCamera = oldCameraSave;


        }
    }

    //checks the current trigger name and moves player based on trigger location
    void positionBasedOnCamera(Collider2D other)
    {
        switch (this.gameObject.name.ToString())
        {
            case "First_Camera_Trigger":
                {
                    directionEnter(other);
                    if (enterFromLeft)  //moves the player past the trigger area based on direction of entering
                    {
                        player.transform.position = new Vector3(this.gameObject.transform.position.x, player.transform.position.y);
                        player.transform.position += new Vector3(1, 0);
                    }
                    else
                    {
                        player.transform.position = new Vector3(this.gameObject.transform.position.x, player.transform.position.y);
                        player.transform.position += new Vector3(-1, 0);
                    }
                    break;
                }
            case "Second_Camera_Trigger":
                {
                    directionEnter(other);
                    if (enterFromAbove)
                    {
                        player.transform.position = new Vector3(player.transform.position.x, this.gameObject.transform.position.y);
                        player.transform.position += new Vector3(0, -2);
                        enterFromAbove = false;
                    }
                    else
                    {
                        player.transform.position = new Vector3(player.transform.position.x, this.gameObject.transform.position.y);
                        player.transform.position += new Vector3(0, 2);
                    }
                    break;
                }
            case "Third_Camera_Trigger":
                {
                    directionEnter(other);
                    if (enterFromAbove)
                    {
                        player.transform.position = new Vector3(player.transform.position.x, this.gameObject.transform.position.y);
                        player.transform.position += new Vector3(0, -2);
                    }
                    else
                    {
                        player.transform.position = new Vector3(player.transform.position.x, this.gameObject.transform.position.y);
                        player.transform.position += new Vector3(0, 2);
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    void directionEnter(Collider2D other)
    {
        if (other.transform.position.x < this.transform.position.x)     //reminder - look at GamePlayProgramming project - used certain method for checking direction of entering trigger
        {
            enterFromLeft = true;   //these bool values are used for pushing the character past the trigger area
        }
        else if (other.transform.position.x > this.transform.position.x)
        {
            enterFromLeft = false;
        }

        if (other.transform.position.y < this.transform.position.y)
        {
            enterFromAbove = false;
        }
        else if (other.transform.position.y > this.transform.position.y)
        {
            enterFromAbove = true;
        }
    }
}