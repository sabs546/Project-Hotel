using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public int itemID;
    private InventoryMGR inventoryMGR;
    public bool showing;
    // Start is called before the first frame update
    void Start()
    {
        inventoryMGR = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryMGR>();
        showing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallManager()
    {
        if (inventoryMGR.fullHide)
        {
            showing = false;
            inventoryMGR.fullHide = false;
        }

        if (!showing)
            inventoryMGR.ShowItem(itemID);
        else
            inventoryMGR.HideItem();
        showing = !showing;
    }
}
