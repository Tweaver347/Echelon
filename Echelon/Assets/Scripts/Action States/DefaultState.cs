using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : ActionBaseState
{
    public override void EnterState(ActionStateManager actions)
    {

    }

    public override void UpdateState(ActionStateManager actions)
    {
        if (Input.GetKeyDown(KeyCode.R) && CanReload(actions))
        {
            actions.SwitchState(actions.Reload);
        }
    }

    bool CanReload(ActionStateManager action)
    {
        if (action.ammo.currentAmmo == action.ammo.clipSize)
        {
            return false;
        }
        else if (action.ammo.extraAmmo == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
