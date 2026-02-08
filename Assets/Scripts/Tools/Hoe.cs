using UnityEngine;

public class Hoe : Tool
{
    CellData cellData;
    Vector2Int cellPos;

    public override bool StartingUsing(CellUseContext cellUseContext)
    {
        cellData = cellUseContext.cellData;
        cellPos = cellUseContext.cell;

        return true;
    }

    public override void FinishUsing(){}
}
