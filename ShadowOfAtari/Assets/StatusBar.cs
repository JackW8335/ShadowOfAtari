using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{

    private float current_health;
    private float max_health;
    public Slider healthbar;

    // Use this for initialization
    void Start()
    {
        current_health = 100.0f;
        max_health = 100.0f;
        healthbar.value = current_health;
    }

    // Update is called once per frame
    void Update()
    {
        //test binding remove in final, deals damage when you press X

        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(10);
        }
    }

    void DealDamage(int damage)
    {
        current_health -= damage;
        healthbar.value = current_health;
    }

    void Die()
    {
        if (healthbar.value == 0)
        {

        }
    }

    //use for calclutating percentages
    float CalculateHealth()
    {
        return current_health / max_health;
    }
}
