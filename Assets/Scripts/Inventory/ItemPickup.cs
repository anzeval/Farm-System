using System;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] ItemSO item;
    [SerializeField] int amount = 1;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.Icon;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        InventoryController inventoryController = other.GetComponent<InventoryController>();
        if(inventoryController == null || !other.CompareTag("Player") || !inventoryController.CanBeAdded(item)) return;

        inventoryController.AddItem(new InventorySlot(item, amount));
        Destroy(gameObject);
    }
}
