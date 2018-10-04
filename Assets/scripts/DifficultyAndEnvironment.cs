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
}
