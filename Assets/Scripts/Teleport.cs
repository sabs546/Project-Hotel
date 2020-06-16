using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject location;
    public GameObject camLocation;
    public Camera camera;
    public GameObject wipe;
    public GameObject player;

    private RectTransform wipeRect;
    private bool transition;
    private AudioSource source;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        transition = false;
        wipeRect = wipe.GetComponent<RectTransform>();
        source = GetComponent<AudioSource>();
        spr = wipeRect.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transition)
        {
            if (wipeRect.localScale.y < 1750.0f)
            {
                wipeRect.localScale = new Vector3(wipeRect.localScale.x, wipeRect.localScale.y + 10.0f, wipeRect.localScale.x);
            }
            else
            {
                player.transform.position = location.transform.position;
                camera.transform.position = camLocation.transform.position;
                if (spr.color.a > 0.0f)
                    spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, spr.color.a - 1.0f * Time.deltaTime);
                else
                {
                    wipeRect.localScale = new Vector3(wipeRect.localScale.x, 0.0f, wipeRect.localScale.x);
                    spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1.0f);
                    transition = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        source.Play();
        transition = true;
    }
}
