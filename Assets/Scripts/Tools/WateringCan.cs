using UnityEngine;

public class WateringCan : Tool
{
    CellData cellData;
    Vector2Int cellPos;

    public override bool StartingUsing(CellUseContext cellUseContext)
    {
        cellData = cellUseContext.cellData;
        cellPos = cellUseContext.cell;

        WaterSoil();
        return true;
    }

    private void WaterSoil()
    {
        if(cellData.CellType == CellType.soil && cellData.IsWatered == false && cellData.CurrentStage != SoilStage.barren && cellData.CurrentStage != SoilStage.ripe)
        {
            cellData.IsWatered = true;
        }
    }

    public override void FinishUsing(){}
}
