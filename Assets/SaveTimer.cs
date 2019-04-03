using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimer : MonoBehaviour
{
    public float savedTime = 0;

    private Timer timer;
	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        savedTime = timer.time;
	}
}
