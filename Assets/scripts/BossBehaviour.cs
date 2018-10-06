using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour
{

    // Use this for initialization
    private float max_health = 100;
    public float health;
    private float time;
    private float rand;

    public Slider health_bar;
    public enum boss_states { SHAKING, NORMAL };

    public boss_states state;

    void Start()
    {
        health = max_health;
        health_bar.value = health;
        state = boss_states.NORMAL;
        time = 0.0f;

         rand = Random.Range(5.0f,10.0f);

}

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X))
        {

            //DealDamage(10);
            //stamina -= 50;
            health_bar.value = health -= 10;

        }

        if (time >= rand)
        {
            
            state = boss_states.SHAKING;
        }
        if (time >= rand + 5)
        {

            state = boss_states.NORMAL;
            time = 0.0f;
            rand = Random.Range(5.0f, 10.0f);
        }


    }

    void WeakSpotHit()// need ref to game object 
    {
        // deavtivate weak spot / turn of weak spot effect 
    }

}
