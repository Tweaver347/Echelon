using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : MovementBaseState
{
    public override void EnterState(Movement movement)
    {
        // movement.aimManager.changeAimPoint(1); // changing the aimpoint to 1 will change it to crouching aimpoint

        movement.anim.SetBool("Crouching", true);
    }

    public override void UpdateState(Movement movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.Sprint);

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (movement.dir.magnitude < 0.1f) ExitState(movement, movement.Idle);
            else ExitState(movement, movement.Walk);
        }

        if (movement.vertInput < 0)
        {
            movement.currentMoveSpeed = movement.crouchBackSpeed;
        }
        else
        {
            movement.currentMoveSpeed = movement.crouchSpeed;
        }
    }

    void ExitState(Movement movement, MovementBaseState newState)
    {
        //movement.aimManager.changeAimPoint(0); // changing the aimpoint to 0 will change the aimpoint to standing aimpoint

        movement.anim.SetBool("Crouching", false);
        movement.SwitchState(newState);
    }
}
