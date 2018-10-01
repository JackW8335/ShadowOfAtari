using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {
    public Camera oldCam;
    public Camera newCam;

	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            oldCam.enabled = false;
            newCam.enabled = true;
        }
    }
}
