using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour {

    private float current_stamina;
    public Slider stamina_bar;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        current_stamina = gameObject.GetComponent<PlayerStats>().stamina;

        stamina_bar.value = current_stamina;
    }
}
