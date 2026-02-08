using UnityEngine;

public class ToolbarUI : MonoBehaviour
{
    [SerializeField] Toolbar toolbar;
    [SerializeField] GameObject[] toolbarActivatorIcons;
    [SerializeField] SlotUI[] toolbarSlots;

    int lastSlot = -1;

    private void OnEnable() 
    {
        toolbar.OnActiveSlotChanged += ChangeSlot;
        toolbar.OnInventoryChanged += UpdateToolbar;
    }

    private void OnDisable()
    {
        toolbar.OnActiveSlotChanged -= ChangeSlot;
        toolbar.OnInventoryChanged -= UpdateToolbar;
    }

    private void Awake() 
    {
        foreach (var item in toolbarActivatorIcons)
        {
            item.SetActive(false);
        }
    }

    private void UpdateToolbar(InventorySlot[] inventorySlots)
    {
        for (int i = 0; i < toolbarSlots.Length; i++)
        {
            toolbarSlots[i].UpdateSlotUIInfo(inventorySlots[i]);
        }
    }

    private void ChangeSlot(int slot)
    {
        if(slot == lastSlot) return;

        ActivateSlot(slot);
        DeactivateSlot(lastSlot);

        lastSlot = slot;
    }

    private void ActivateSlot(int slot)
    {
        toolbarActivatorIcons[slot].SetActive(true);
    }

    private void DeactivateSlot(int slot)
    {
        if(slot < 0) return;

        toolbarActivatorIcons[slot].SetActive(false);
    }
}
