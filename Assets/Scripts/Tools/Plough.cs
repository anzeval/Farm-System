using UnityEngine;

public class Plough : Tool
{
    CellData cellData;
    Vector2Int cellPos;

    public override bool StartingUsing(CellUseContext cellUseContext)
    {
        cellData = cellUseContext.cellData;
        cellPos = cellUseContext.cell;

        PloughSoil();
        
        return true;
    }

    private void PloughSoil()
    {
        if(cellData.CurrentStage == SoilStage.barren && cellData.CellType != CellType.grass)
        {
            cellData.CurrentStage = SoilStage.ploughed;
            cellData.CellType = CellType.soil;
        } 
    }

    public override void FinishUsing(){}
}
