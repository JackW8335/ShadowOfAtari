using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChangeScript : MonoBehaviour {

    public Camera oldCamera;
    public Camera newCamera;
    private Camera oldCameraSave;
    private Camera newCameraSave;
    private int xPos;
    private int yPos;
    private Transform player;

    private void Start()
    {
        newCamera.enabled = false;  //disable all but start camera at beginning
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            oldCameraSave = oldCamera;  //save which cameras were old and new
            newCameraSave = newCamera;
            newCamera.enabled = true;   //disable old camera and enable new
            oldCamera.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            oldCamera = newCameraSave;  //swap active cameras using old saves
            newCamera = oldCameraSave;


        }
    }

    void changePosition()
    {
        if (xPos != 0)
        {
            player.position = new Vector2(xPos, player.position.y);
        }
        if (yPos != 0)
        {
            player.position = new Vector2(player.position.x, yPos);
        }
    }

    void positionBasedOnCamera()
    {
        switch (oldCameraSave.name.ToString())
        {
            case ("Start_Camera"):
                {
                    xPos = -20;
                    break;
                }
            case ("Camera_1"):
                {
                    break;
                }
            case ("Camera_2"):
                {
                    break;
                }
            case ("Camera_3"):
                {
                    break;
                }
        }
    }
}
