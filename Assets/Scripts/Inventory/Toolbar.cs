using System;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
    public event Action<int> OnActiveSlotChanged;
    public event Action<InventorySlot[]> OnInventoryChanged;

    void OnEnable()
    {
        InventoryController.Instance.OnActiveSlotChanged += ChangeActiveSlot;
        InventoryController.Instance.OnInventaryChanged += UpdateInventoryInfo;
    }

    void OnDisable()
    {
        InventoryController.Instance.OnActiveSlotChanged -= ChangeActiveSlot; 
        InventoryController.Instance.OnInventaryChanged -= UpdateInventoryInfo;
    }

    public void ChangeActiveSlot(int slot)
    {
        OnActiveSlotChanged.Invoke(slot);
    }

    public void UpdateInventoryInfo(InventorySlot[] inventorySlots)
    {
        OnInventoryChanged.Invoke(inventorySlots);
    }
}