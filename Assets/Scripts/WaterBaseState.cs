using UnityEngine;

public abstract class WaterBaseState
{
    public abstract void EnterState(WaterStateManager water);
    public abstract void UpdateState(WaterStateManager water);
}
