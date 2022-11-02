using UnityEngine;

public class WaterFullState : WaterBaseState
{
    private float spoillingWaterDelay;

    public override void EnterState(WaterStateManager water)
    {
        spoillingWaterDelay = 5f;

        if (water.IsAutomatic == false)
        {
            water.EnableButton(water.UI.ButtonPouring);
        }

        water.Timer = spoillingWaterDelay;
    }

    public override void UpdateState(WaterStateManager water)
    {
        spoillingWaterDelay -= Time.deltaTime;
        if (spoillingWaterDelay <= 0f)
        {
            water.SwitchState(water.SpoillingState);
        }
    }
}
