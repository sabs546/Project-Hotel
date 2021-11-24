using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwap : MonoBehaviour
{
    public string targetLayer;
    public int targetOrder;
    public string previousLayer;
    public int previousOrder;

    private List<SpriteRenderer> sprites;

    // Start is called before the first frame update
    void Start()
    {
        sprites = new List<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sprites.Add(collision.GetComponent<SpriteRenderer>());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        foreach (SpriteRenderer sprite in sprites)
        { // Move them over to the new layer (or back to the old one)
            sprite.sortingLayerName = targetLayer;
            sprite.sortingOrder = targetOrder;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().sortingLayerName = previousLayer;
        collision.GetComponent<SpriteRenderer>().sortingOrder = previousOrder;
        sprites.Remove(collision.GetComponent<SpriteRenderer>());
    }
}
