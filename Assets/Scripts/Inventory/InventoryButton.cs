using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public int itemID;
    private InventoryMGR inventoryMGR;
    private EquipItem equipItem;
    public bool showing;
    // Start is called before the first frame update
    void Start()
    {
        inventoryMGR = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryMGR>();
        equipItem = GameObject.FindGameObjectWithTag("EquipBox").GetComponentInChildren<EquipItem>();
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
        {
            inventoryMGR.ShowItem(itemID);
            inventoryMGR.equippedItem = itemID;
        }
        else
        {
            inventoryMGR.HideItem();
            inventoryMGR.equippedItem = -1;
        }
        showing = !showing;

        equipItem.ChangeDisplay();
    }
}
