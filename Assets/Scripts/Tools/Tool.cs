using UnityEngine;

public abstract class Tool : MonoBehaviour, IUsable
{
    public abstract bool StartingUsing(CellUseContext cellUseContext);
    public abstract void FinishUsing();
}
