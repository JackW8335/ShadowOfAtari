using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    private playerBehaviour player;
    private Text text;
    int stamina = 0;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerBehaviour>();
        text = GetComponent<Text>();
        stamina = (int)player.Grip;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if ((int)player.Grip % 5 == 0)
        {
            stamina = (int)player.Grip;
            text.text = stamina.ToString();
        }
	}
}
