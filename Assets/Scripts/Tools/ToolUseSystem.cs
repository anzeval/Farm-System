using UnityEngine;

public class ToolUseSystem : MonoBehaviour
{
   [SerializeField] PlayerInputHandler playerInputHandler;
   [SerializeField] ToolIndicator toolIndicator;
   [SerializeField] ActiveItem activeItem;
    [SerializeField] GridController gridController;

    void Update()
    {
        if (gridController == null)
            return;

        if (activeItem.HasItem() && playerInputHandler.IsAttacking && CanUseTool())
        {
            activeItem.StartUse(GetCellUseContext());
        } else
        {
            activeItem.FinishUse();
        }
    }

    private CellUseContext GetCellUseContext()
    {
        CellUseContext cellUseContext = new CellUseContext();
        cellUseContext.cell = toolIndicator.currentCell;
        cellUseContext.cellData = gridController.GetCell(toolIndicator.currentCell);

        return cellUseContext;
    }

    private bool CanUseTool()
    {
        return toolIndicator.IsCellInRange && gridController.GetCell(toolIndicator.currentCell) != null;
    }
}
