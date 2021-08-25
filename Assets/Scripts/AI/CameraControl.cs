using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public bool unlockX;
    public bool unlockY;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unlockY && player.position.y > minY && player.position.y < maxY)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
}