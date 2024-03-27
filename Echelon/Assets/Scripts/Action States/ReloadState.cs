using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState : ActionBaseState
{
    public override void EnterState(ActionStateManager actions)
    {
        actions.anim.SetTrigger("Reload");
    }

    public override void UpdateState(ActionStateManager actions)
    {

    }
}

