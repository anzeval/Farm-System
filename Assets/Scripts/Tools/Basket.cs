using UnityEngine;
using System;

public class Basket : Tool
{
    CellData cellData;
    Vector2Int cellPos;
    
    public static event Action<ItemSO, int> OnHarvested;

    public override bool StartingUsing(CellUseContext cellUseContext)
    {
        cellData = cellUseContext.cellData;
        cellPos = cellUseContext.cell;

        HarvestPlant();
        return true;
    }

    private void HarvestPlant()
    {
        if(cellData.CellType == CellType.soil && cellData.CurrentStage == SoilStage.ripe)
        {
            ItemSO item = cellData.SeedData.harvestItem;
            int amount = cellData.SeedData.harvestAmount;

            OnHarvested?.Invoke(item, amount);

            cellData.CurrentStage= SoilStage.ploughed;
            cellData.IsWatered = false;
            cellData.SeedData = null;
        } 
        else if (cellData.CellType == CellType.grass)
        {
            cellData.CellType = CellType.ground;

            if(cellData.Entity != null)
            {
                cellData.Entity.ApplyTool(ToolType.basket);
            }
        }
    }

    public override void FinishUsing(){}
}
