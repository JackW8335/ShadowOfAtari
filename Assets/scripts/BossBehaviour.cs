using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour {

    // Use this for initialization
    private float max_health = 100;
    public float health;
    public Slider health_bar;
    

    void Start () {
        health = max_health;
        health_bar.value = health;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {

            //DealDamage(10);
            //stamina -= 50;
            health_bar.value = health -= 10;
         
        }
    }

    void WeakSpotHit()// need ref to game object 
    {
        // deavtivate weak spot / turn of weak spot effect 
    }


}
