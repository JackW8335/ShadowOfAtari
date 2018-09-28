using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int max_health;
    public int health;
    public int stamina;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(10);
            stamina -= 50;
        }
        
    }



    void DealDamage(int damage)
    {
        health -= damage;
    }
}
