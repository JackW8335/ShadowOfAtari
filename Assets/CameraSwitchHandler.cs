using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchHandler : MonoBehaviour {

    public Camera[] Cameras;
    public GameObject[] Triggers;
    public GameObject player;
    public float dir;
    public float dist;
    public int cameraNum;
    public int cameraToUse = 0;

    private void Start()
    {
        setCameras();
        cameraToUse = 0;
    }

    private void Update()
    {
        checkAllTriggers();
    }

    void checkAllTriggers()
    {
        for (int i = 0; i < Triggers.Length; i++)
        {
            GameObject trigger = Triggers[i];
            //only works one way 
            dist = Vector2.Distance(player.transform.position, trigger.transform.position);

            if (dist <= 1)
            {
                dir = FindHeading(i);
                if (dir > 0)
                {
                    cameraNum = i - 1;
                    //cameraToUse++;
                }
                else if (dir < 0)
                {
                    cameraNum = i + 1;
                    //cameraToUse--;
                }

                setCameras();
            }
        }
    }

    GameObject FindNextTrigger()
    {
        GameObject target;
        switch (cameraToUse)
        {
            case 0:
                target = Triggers[0];
                break;

            case 1:
                target = Triggers[0];
                break;

            default:
                target = Triggers[0];
                break;

        }
        return target;
    }

float FindHeading(int i)
    {
        float mod = 0;
        Vector2 heading = Triggers[i].transform.position - player.transform.position;
        if(i ==0)
        {
            mod = heading.normalized.x;
        }
        else
        {
            mod = heading.normalized.y;
        }

        return mod;
    }

    void setCameras()
    {
        Cameras[cameraNum].gameObject.SetActive(true);
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i != cameraNum)
            {
                Cameras[i].gameObject.SetActive(false);
            }
        }
    }
}

   

