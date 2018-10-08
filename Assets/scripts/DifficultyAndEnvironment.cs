using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyAndEnvironment : MonoBehaviour
{
    public BossBehaviour boss;

    public Camera cam;
    public Renderer[] rend;
    public Material[] mats;
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        changeDifficulty();

        if (boss.state == BossBehaviour.boss_states.SHAKING)
        {
            shaking(1.0f, 0.4f);
        }
        

    }

    void changeDifficulty()
    {
        if (boss.health <= 60)
        {

            for (int i = 0; i < rend.Length; i++)
            {
                rend[i].sharedMaterial = mats[0];
            }
        }
        if (boss.health <= 30)
        {

            for (int i = 0; i < rend.Length; i++)
            {
                rend[i].sharedMaterial = mats[1];
            }

        }


    }

    void shaking(float duration, float magnitude)
    {

        Vector3 originalPos = transform.localPosition;

        float x = Random.Range(-0.2f, 0.2f) * magnitude;
            //float y = Random.Range(-1.0f, 1.0f) * magnitude;

            transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);
        
    }
}

