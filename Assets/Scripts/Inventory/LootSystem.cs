using UnityEngine;

public class LootSystem : MonoBehaviour
{
    private void OnEnable()
    {
        CellEntityBase.OnLootDropped += HandleLoot;
    }

    private void OnDisable()
    {
        CellEntityBase.OnLootDropped -= HandleLoot;
    }

    private void HandleLoot(LootContext loot)
    {
        InventoryController.Instance.AddItem(new InventorySlot(loot.ItemSO, loot.Amount));
    }
}
