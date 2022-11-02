using Unity.VisualScripting;
using UnityEngine;

public class WaterSpoilageState : WaterBaseState
{
    private float spoilageDuration;
    private float spoilageSpeed;
    private float spoilageStartingValue;

    public override void EnterState(WaterStateManager water)
    {
        spoilageDuration = 5f;
        spoilageSpeed = 0.05f;
        spoilageStartingValue = spoilageSpeed;

        water.Timer = spoilageDuration;
    }

    public override void UpdateState(WaterStateManager water)
    {
        if (water.IsAutomatic)
        {
            spoilageDuration -= Time.deltaTime;
            if (spoilageDuration <= 0f)
            {
                water.SwitchState(water.PouringOutState);
            }
        }

        spoilageSpeed -= Time.deltaTime;
        if (spoilageSpeed <= 0f)
        {
            spoilageSpeed = spoilageStartingValue;
            for (int i = 0; i < water.waterList.Count; i++)
            {
                SpriteRenderer spriteRenderer = water.waterList[i].GameObject().GetComponent<SpriteRenderer>();
                var currentCololor = spriteRenderer.color;
                spriteRenderer.color = new Color(currentCololor.r, currentCololor.g, currentCololor.b - 0.02f, currentCololor.a);
            }
        }
    }
}
