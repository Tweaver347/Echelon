using UnityEngine;

public class HipfireState : AimBaseState
{
    public override void EnterState(AimManager aim)
    {
        aim.anim.SetBool("Aiming", false);
        aim.currFOV = aim.hipFOV;
    }

    public override void UpdateState(AimManager aim)
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            aim.SwitchState(aim.Aim);
        }
    }
}
