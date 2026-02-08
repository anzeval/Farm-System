using UnityEngine;
using System;

public class ActiveItem : MonoBehaviour
{
    GameObject item;
    ItemSO itemData;
    IUsable usable;

    public event Action<ItemSO> OnItemUsed;

    void OnEnable()
    {
        InventoryController.Instance.OnActiveItemChanged += SetActive;
    }

    void OnDisable()
    {
        InventoryController.Instance.OnActiveItemChanged -= SetActive; 
    }

    public void SetActive(ItemSO itemSO)
    {
        UnequipItem();
        itemData = itemSO;
        EquipItem();
    }

    public bool HasItem()
    {
        return item != null;
    }

    private void EquipItem()
    {
        if(itemData == null) return;
        item = Instantiate(itemData.Prefab, transform.position, Quaternion.identity,gameObject.transform);
        
        if(item.TryGetComponent<IUsable>(out IUsable component))
        {
            usable = component;    
        } else
        {
            Debug.LogError("There is no IUsable component on this item.");
        }    
    }

    private void UnequipItem()
    {
        if(item == null) return;

        Destroy(item);
        usable = null;
    }

    public void StartUse(CellUseContext cellUseContext)
    {
        if(usable == null) return;

        bool success = usable.StartingUsing(cellUseContext);
        if(!success) return;

        OnItemUsed?.Invoke(itemData);
    }

    public void FinishUse()
    {
        if(usable == null) return;

        usable.FinishUsing();
    }
}
