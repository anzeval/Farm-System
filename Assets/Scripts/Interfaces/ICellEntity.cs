public interface ICellEntity
{
    bool CanBeDestroyedBy(ToolType tool);
    void ApplyTool(ToolType tool);
    void Destroy();
}

public enum ToolType
{
    plough,
    basket,
    wateringCan
}

