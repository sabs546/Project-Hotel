using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorID : MonoBehaviour
{
    public AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { // Change step sounds based on the floor you're on
        collision.GetComponent<SFXManager>().Surface(clip);
    }
}
