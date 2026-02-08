using UnityEngine;

public class GrassEntity : CellEntityBase
{
    [SerializeField] int minSeeds = 1;
    [SerializeField] int maxSeeds = 3;
    [SerializeField] ItemSO[] itemSOs;

    public override bool CanBeDestroyedBy(ToolType tool)
        => tool == ToolType.basket;

    public override void ApplyTool(ToolType tool)
    {
        if (!CanBeDestroyedBy(tool)) return;

        DropLoot(new LootContext
        {
            ItemSO = itemSOs[Random.Range(0, itemSOs.Length)],
            Amount = Random.Range(minSeeds, maxSeeds + 1)
        });

        Destroy();
    }
}
