using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextID : MonoBehaviour
{
    public GameObject interaction;
    public int itemID;
    [HideInInspector]
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInteraction(bool setting)
    {
        active = setting;
        interaction.SetActive(active);
    }
}
