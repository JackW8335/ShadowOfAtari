using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviourScript : MonoBehaviour {

    // Use this for initialization
    public int health;

    public Slider health_bar;
    void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {

        health_bar.value = health;
    }

    public int getHeath()
    {
        return health;
    }

    public void setHeath(int nwHealth)
    {
        health = nwHealth;
    }

    public void turnOffWeakSpot(string weakspotName)
    {
        GameObject weakSpot = GameObject.Find(weakspotName);
        weakSpot.SetActive(false);
    }
}