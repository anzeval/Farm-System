using UnityEngine;

public abstract class CellEntityBase : MonoBehaviour, ICellEntity
{
    public abstract bool CanBeDestroyedBy(ToolType tool);

    public abstract void ApplyTool(ToolType tool);

    public static event System.Action<LootContext> OnLootDropped;

    protected void DropLoot(LootContext loot)
    {
        OnLootDropped?.Invoke(loot);
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}

public struct LootContext
{
    public ItemSO ItemSO;
    public int Amount;
}