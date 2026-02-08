using UnityEngine;

public abstract class Seed : MonoBehaviour, IUsable
{
    public abstract bool StartingUsing(CellUseContext cellUseContext);
    public abstract void FinishUsing();
}