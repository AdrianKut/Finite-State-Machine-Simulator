using UnityEngine;

public class WaterPouringOutState : WaterBaseState
{
    private float pouringDuration;
    private Animator animator;

    public override void EnterState(WaterStateManager water)
    {
        pouringDuration = 3f;

        animator = water.GetComponent<Animator>();
        animator.SetTrigger("OpenBottom");

        water.Timer = pouringDuration;
    }

    public override void UpdateState(WaterStateManager water)
    {
        pouringDuration -= Time.deltaTime;
        if (pouringDuration <= 0f)
        {
            animator.SetTrigger("CloseBottom");

            if (water.IsAutomatic)
            {
                water.StartAutomaticSimulation();
                water.DestroyAllWaterElements();
                return;
            }

            water.StopSimulation();
            water.EnableButton(water.UI.ButtonFilling);
            water.EnableButton(water.UI.ButtonAutomatic);
        }
    }
}
