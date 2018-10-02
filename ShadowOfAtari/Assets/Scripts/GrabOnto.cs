using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOnto : MonoBehaviour
{

    private bool onBoss = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("Fire1"))
            {
                if(!onBoss)
                {
                    onBoss = true;
                    /*Code to attach player to boss here,
                    need player stuff before adding more*/
                }
                else
                {
                    //Detach from the boss
                }

            }
        }
    }
}
