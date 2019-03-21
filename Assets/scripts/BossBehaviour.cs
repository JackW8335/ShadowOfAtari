using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BOSS_STATES
{
    SHAKING,
    NORMAL,
    SWOOPING,
    DEAD
};

public class BossBehaviour : MonoBehaviour
{

    // Use this for initialization
    protected float max_health = 100;
    public float health;
    protected float time;
    protected float rand;



    public BOSS_STATES state;

    public string levelToLoad;

    private AudioSource hurtNoise;

    protected virtual void Start()
    {
        hurtNoise = this.GetComponent<AudioSource>();
        health = max_health;
        state = BOSS_STATES.NORMAL;
        time = 0.0f;

         rand = Random.Range(5.0f,10.0f);

}

    // Update is called once per frame
    protected virtual void Update()
    {
        if(health <= 0.0f)
        {
            state = BOSS_STATES.DEAD;
            SceneManager.LoadScene(levelToLoad);
              
        }
        time += Time.deltaTime;
        
        if (time >= rand)
        {
            
            state = BOSS_STATES.SHAKING;
        }
        if (time >= rand + 5)
        {

            state = BOSS_STATES.NORMAL;
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
    }

    public void turnOffWeakSpot(string weakspotName)
    {
        hurtNoise.Play();
        GameObject weakSpot = GameObject.Find(weakspotName);
        weakSpot.SetActive(false);
    }
}
