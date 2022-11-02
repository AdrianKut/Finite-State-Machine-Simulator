using UnityEngine;

public class WaterFillingState : WaterBaseState
{
    private float fillingDuration;
    private float fillingRate;
    private float fillingRateStartingValue;

    public override void EnterState(WaterStateManager water)
    {
        fillingRate = 0.15f;
        fillingRateStartingValue = fillingRate;
        fillingDuration = 10f;

        water.Timer = fillingDuration;
    }

    public override void UpdateState(WaterStateManager water)
    {
        fillingDuration -= Time.deltaTime;
        fillingRate -= Time.deltaTime;

        if (fillingDuration <= 0f)
        {
            water.SwitchState(water.FullState);
        }

        if (fillingRate <= 0f)
        {
            fillingRate = fillingRateStartingValue;
            water.FillingWater();
        }
    }
}
