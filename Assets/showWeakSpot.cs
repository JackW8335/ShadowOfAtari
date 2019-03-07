using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showWeakSpot : MonoBehaviour {


    public GameObject player;
    private float distance = 0;

	// Use this for initialization
	void Start ()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        checkingDistances();
        showSpots();
        //Debug.Log(distance);

    }

    void checkingDistances()
    {
        distance = Vector2.Distance(this.transform.position, player.transform.position);
    }

    void showSpots()
    {
        if (distance <= 4)
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
