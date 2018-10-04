using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWeakSpot : MonoBehaviour
{
    private bool beenAttacked = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown("Fire1") && !beenAttacked)
            {
                /* Do damage to boss, need player before I add more
                Play sound effect, boss hurt
                Flash on screen or something too */
                beenAttacked = true;
            }
        }
    }


}
