using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Animator anim;

    private bool attacking = false;


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking)
        {
            StartCoroutine(wait());
        }
        else if (attacking)
        {
            anim.SetBool("Attack", false);
        }
    }

    private IEnumerator wait()
    {
        anim.SetBool("Attack", true);
        attacking = true;
        yield return new WaitForSeconds(14);
        attacking = false;


    }
}
