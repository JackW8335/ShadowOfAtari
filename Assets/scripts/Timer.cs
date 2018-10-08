using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float time = 0;
    public float bestTime = 0;

    private Text score;

	// Use this for initialization
	void Start ()
    {
        time = Time.time;
        score = this.GetComponent<Text>();

        

        score.text = time.ToString();

	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        score.text = time.ToString("F1");

	}
}
