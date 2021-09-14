using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Teleport : MonoBehaviour
{
    public GameObject      location;
    public GameObject      camLocation;
    public GameObject      wipe;
    public GameObject      player;
    public BaseTask[]      tasks;
    
    private Camera         camera;
    private RectTransform  wipeRect;
    private bool           transition;
    private AudioSource    source;
    private SpriteRenderer spr;
    private Animator       animator;
    // Start is called before the first frame update
    void Start()
    {
        transition = false;
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        wipeRect = wipe.GetComponent<RectTransform>();
        source = GetComponent<AudioSource>();
        spr = wipeRect.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transition)
        { // To stop the rect from constantly changing
            if (wipeRect.localScale.y < 1750.0f)
            { // Expand the wipe
                wipeRect.localScale = new Vector3(wipeRect.localScale.x, wipeRect.localScale.y + 10.0f, wipeRect.localScale.x);
            }
            else
            {
                player.transform.position = location.transform.position;
                camera.transform.position = camLocation.transform.position;
                if (spr.color.a > 0.0f)
                {
                    spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, spr.color.a - 1.0f * Time.deltaTime);
                }
                else
                {
                    wipeRect.localScale = new Vector3(wipeRect.localScale.x, 0.0f, wipeRect.localScale.x);
                    spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1.0f);
                    transition = false;
                }

                if (tasks.FirstOrDefault() != null && !tasks.FirstOrDefault().enabled)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
                    GetComponents<BoxCollider2D>().First(n => !n.isTrigger).enabled = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (source != null)
        {
            source.Play();
        }
        transition = true;
        if (animator != null)
        {
            animator.SetBool("Open", true);
        }

        if (tasks.FirstOrDefault() != null)
        {
            tasks.First().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
        }
    }
}
