using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text count;

    public void UpdateSlotUIInfo(InventorySlot inventorySlot)
    {
        if(inventorySlot.item == null)
        {
            ClearIcon();
            ClearCount();
        }
        else
        {
            SetIcon(inventorySlot.item.Icon);
            SetCount(inventorySlot.count);
        }
    }

    private void SetIcon(Sprite sprite)
    {
        icon.sprite = sprite;
        icon.enabled = true;
    }

    private void ClearIcon()
    {
        icon.sprite = null;
        icon.enabled = false;
    }

    private void SetCount(int newCount)
    {
        count.text = newCount.ToString();
        count.enabled = true;
    }

    private void ClearCount()
    {
        count.text = " ";
        count.enabled = false;
    }
}
