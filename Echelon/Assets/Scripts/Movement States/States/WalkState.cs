using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementBaseState
{
    public override void EnterState(Movement movement)
    {
        movement.anim.SetBool("Walking", true);
    }

    public override void UpdateState(Movement movement)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ExitState(movement, movement.Sprint);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            ExitState(movement, movement.Crouch);
        }
        else if (movement.dir.magnitude < 0.1f)
        {
            ExitState(movement, movement.Idle);
        }

        if (movement.vertInput < 0)
        {
            movement.currentMoveSpeed = movement.walkBackSpeed;
        }
        else
        {
            movement.currentMoveSpeed = movement.walkSpeed;
        }
    }
    void ExitState(Movement movement, MovementBaseState newState)
    {
        movement.anim.SetBool("Walking", false);
        movement.SwitchState(newState);
    }
}
