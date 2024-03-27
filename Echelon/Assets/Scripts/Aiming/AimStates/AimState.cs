using UnityEngine;

public class AimState : AimBaseState
{
    public override void EnterState(AimManager aim)
    {
        aim.anim.SetBool("Aiming", true);
        aim.currFOV = aim.adsFOV;
    }

    public override void UpdateState(AimManager aim)
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            aim.SwitchState(aim.Hip);
        }
    }
}
