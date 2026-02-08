using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject inventorySlotPrefab;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] Transform inventorySlotContainer;
    [SerializeField] GameObject inventoryUI;
    [SerializeField] SlotUI[] inventarySlotsUI;

    void OnDisable()
    {
        InventoryController.Instance.OnInventaryChanged -= UpdateInventoryUI;
        playerInputHandler.OnInventoryInteracted -= SetInventoryVisible;
    }

    void Start()
    {
        InventoryController.Instance.OnInventaryChanged += UpdateInventoryUI;
        playerInputHandler.OnInventoryInteracted += SetInventoryVisible;

        inventarySlotsUI = new SlotUI[InventoryController.Instance.GetInventorySize()];
        SpawnSlots(InventoryController.Instance.GetInventorySize());
        SetInventoryVisible(false);
    }

    void UpdateInventoryUI(InventorySlot[] inventorySlots)
    {
        for (int i = 0; i < inventarySlotsUI.Length; i++)
        {
            inventarySlotsUI[i].UpdateSlotUIInfo(inventorySlots[i]);
        }
    }

    void SpawnSlots(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, transform.position, Quaternion.identity, inventorySlotContainer);
            inventarySlotsUI[i] = slot.GetComponent<SlotUI>();
        }
    }

    void SetInventoryVisible(bool isVisible)
    {
        inventoryUI.SetActive(isVisible);
    }
}
