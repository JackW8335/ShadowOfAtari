using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {

    // Use this for initialization
    private float Health = 100;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void WeakSpotHit()// need ref to game object 
    {
        // deavtivate weak spot / turn of weak spot effect 
    }

    float getHealth()
    {
        return Health;
    }

    void setHealth(float nwHealth)
    {
        Health = nwHealth;
    }

}
