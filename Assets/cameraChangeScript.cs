using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraChangeScript : MonoBehaviour {

    public Camera oldCamera;
    public Camera newCamera;
    private Camera oldCameraSave;
    private Camera newCameraSave;

    private void Start()
    {
        newCamera.enabled = false;  //disable all but start camera at beginning
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
}
