using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip[] clip;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeNoise()
    {
        source.clip = clip[Random.Range(0, clip.Length)];
        source.Play();
    }

    public void Surface(AudioClip[] newClip)
    {
        for (int i = 0; i < clip.Length; i++)
        {
            clip[i] = newClip[i];
        }
    }
}
