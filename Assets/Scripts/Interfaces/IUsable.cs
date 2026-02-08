public interface IUsable
{
    bool StartingUsing(CellUseContext cellUseContext);
    void FinishUsing();
}
