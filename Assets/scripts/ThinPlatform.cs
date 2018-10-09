using System.Collections;
using UnityEngine;

public class ThinPlatform : MonoBehaviour {

    public GameObject platform;
    Collider2D col;
    // Use this for initialization
    void Start()
    {
        col = platform.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            col.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            col.enabled = true;
        }
    }
}
