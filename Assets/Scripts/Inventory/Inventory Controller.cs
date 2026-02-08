using UnityEngine;
using System;

public class InventoryController : MonoBehaviour
{
    [SerializeField, Range(10,30)] int inventorySize = 10;
    [SerializeField] int maxStack = 10;
    [SerializeField] PlayerInputHandler playerInputHandler;
    [SerializeField] ActiveItem activeItem;

    public static InventoryController Instance;
    InventorySlot[] inventorySlots;
    int activeSlot = -1;

    public event Action<int> OnActiveSlotChanged;
    public event Action<ItemSO> OnActiveItemChanged;
    public event Action<InventorySlot[]> OnInventaryChanged;

    void OnEnable()
    {
        playerInputHandler.OnSlotSelected += SlotSelectedHandler;
        activeItem.OnItemUsed += HandleItemUsed;
        Basket.OnHarvested += AddHarvest;
    }

    void OnDisable()
    {
        playerInputHandler.OnSlotSelected -= SlotSelectedHandler; 
        activeItem.OnItemUsed -= HandleItemUsed;
        Basket.OnHarvested -= AddHarvest;
    }

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }

        inventorySlots = new InventorySlot[inventorySize];

        for (int i = 0; i < inventorySlots.Length; i++)
        { 
            inventorySlots[i] = new InventorySlot(null, 0); 
        }        
    }

    public void AddItem(InventorySlot newItem)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if(inventorySlots[i].item == newItem.item)
            {
                int totalCount = inventorySlots[i].count + newItem.count;
                if(totalCount > maxStack)
                {
                    inventorySlots[i].count = maxStack;
                    newItem.count = totalCount - maxStack;
                    continue;
                } else
                {
                    inventorySlots[i].count += newItem.count;
                }
            }
            else if(inventorySlots[i].item != null) 
            {
                continue;
            } 
            else
            {
                inventorySlots[i] = newItem;
            }
            OnInventaryChanged?.Invoke(inventorySlots);
            return;
        }
    }


    void AddHarvest(ItemSO item, int amount)
    {
        AddItem(new InventorySlot(item, amount));
    }

    void HandleItemUsed(ItemSO item)
    {
        if(item == null || IsTool(item)) return;

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].item == item)
            {
                DecreaseItemCount(i);
                return;
            }
        }
    }

    bool IsTool(ItemSO itemSO)
    {
        return itemSO.ItemType == ItemType.Tool;
    }

    private void DeleteItem(int slot)
    {
        if(activeSlot < 0) return;

        inventorySlots[slot] = new InventorySlot(null, 0);
        OnInventaryChanged?.Invoke(inventorySlots);
        OnActiveItemChanged?.Invoke(null);
    }

    private void IncreaseItemCount(int slot)
    {
        inventorySlots[slot].count++;
        OnInventaryChanged?.Invoke(inventorySlots);
    }

    private void DecreaseItemCount(int slot)
    {
        inventorySlots[slot].count--;
        if(inventorySlots[slot].count <= 0)
            DeleteItem(slot);
        
        OnInventaryChanged?.Invoke(inventorySlots);
    }

    public bool CanBeAdded(ItemSO item)
    {
        foreach(var slot in inventorySlots)
        {
            if(slot.item == item) return true;
            if(slot.item == null) return true;
        }
        return false;
    }

    private int GetSlotCount(int slot)
    {
        return inventorySlots[slot].count;
    }

    private ItemSO GetSlotData(int slot)
    {
        return inventorySlots[slot].item;
    }

    private int GetActiveSlot()
    {
        return activeSlot;
    }

    private InventorySlot GetActiveItem()
    {
        return inventorySlots[activeSlot];
    }

    public void SlotSelectedHandler(int slot)
    {
        //if the same slot --> ignore
        if(activeSlot == slot || slot < 0 || slot >= inventorySlots.Length) return;
        activeSlot = slot;

        ItemSO item = GetSlotData(activeSlot);

        OnActiveItemChanged?.Invoke(item);
        OnActiveSlotChanged?.Invoke(slot);
    }

    public int GetInventorySize()
    {
        return inventorySize;
    }
}