using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private float current_health;
    private float max_health;
    public Slider healthbar;
    public 

    //// Use this for initialization
    //void Start()
    //{

    //    max_health = gameObject.GetComponent<PlayerStats>().max_health;
    //    current_health = gameObject.GetComponent<PlayerStats>().health;
       
    //    healthbar.value = current_health;
    //    //Debug.Log(player.health);
    //}

    // Update is called once per frame
    void Update()
    {
        //max_health = gameObject.GetComponent<PlayerStats>().max_health;
        current_health = gameObject.GetComponent<PlayerStats>().health;

        healthbar.value = current_health;
        //test binding remove in final, deals damage when you press X

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    DealDamage(10);
        //}
    }

    //use for calclutating percentages
    float CalculateHealth()
    {
        return current_health / max_health;
    }
}
