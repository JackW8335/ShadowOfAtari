using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int max_health;
    public int health;
    public int stamina;

    public Slider health_bar;
    public Slider stamina_bar;

    // Use this for initialization
    void Start()
    {
        health_bar.value = max_health;
        stamina_bar.value = stamina;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

            //DealDamage(10);
            //stamina -= 50;
            health_bar.value = health -= 10;
            stamina_bar.value = stamina -= 20;
        }

    }



    void DealDamage(int damage)
    {
        health -= damage;
    }
}
