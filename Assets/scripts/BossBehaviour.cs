using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossBehaviour : MonoBehaviour
{

    // Use this for initialization
    private float max_health = 100;
    public float health;
    private float time;
    private float rand;

    public Slider health_bar;
    public enum boss_states { SHAKING, NORMAL, DEAD };

    public boss_states state;

    private AudioSource hurtNoise;

    void Start()
    {
        hurtNoise = this.GetComponent<AudioSource>();
        health = max_health;
        health_bar.value = health;
        state = boss_states.NORMAL;
        time = 0.0f;

         rand = Random.Range(5.0f,10.0f);

}

    // Update is called once per frame
    void Update()
    {
        if(health <= 0.0f)
        {
            state = boss_states.DEAD;
            SceneManager.LoadScene("Victory");
              
        }
        time += Time.deltaTime;
        
        if (time >= rand)
        {
            
            state = boss_states.SHAKING;
        }
        if (time >= rand + 5)
        {

            state = boss_states.NORMAL;
            time = 0.0f;
            rand = Random.Range(5.0f, 10.0f);
        }


    }
    public float getHeath()
    {
        return health;
    }

    public void setHeath(float nwHealth)
    {
        health = nwHealth;
        health_bar.value = health;
    }

    public void turnOffWeakSpot(string weakspotName)
    {
        hurtNoise.Play();
        GameObject weakSpot = GameObject.Find(weakspotName);
        weakSpot.SetActive(false);
    }
}
