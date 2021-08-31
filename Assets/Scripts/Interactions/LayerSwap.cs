using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwap : MonoBehaviour
{
    public string targetLayer;
    public int targetOrder;
    public string previousLayer;
    public int previousOrder;

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        sprite = collision.gameObject.GetComponent<SpriteRenderer>();
        // Move them over to the new layer (or back to the old one)
        sprite.sortingLayerName = targetLayer;
        sprite.sortingOrder = targetOrder;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.sortingLayerName = previousLayer;
        sprite.sortingOrder = previousOrder;
    }
}
