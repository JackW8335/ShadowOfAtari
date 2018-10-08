using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackActivation : MonoBehaviour
{
    private bool doOnce = false;
    public GameObject bossAttack;
	// Use this for initialization
	void Start ()
    {
        bossAttack.GetComponent<BossAttack>().enabled = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !doOnce)
        {
            if(!bossAttack.GetComponent<BossAttack>().enabled)
            {
                bossAttack.GetComponent<BossAttack>().enabled = true;
                doOnce = true;
            }
            else if (bossAttack.GetComponent<BossAttack>().enabled)
            {
                bossAttack.GetComponent<BossAttack>().enabled = false;
                doOnce = true;
            }
        }
    }

}
