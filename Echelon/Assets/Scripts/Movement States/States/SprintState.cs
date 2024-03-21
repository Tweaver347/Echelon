using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : MovementBaseState
{
    public override void EnterState(Movement movement)
    {
        movement.anim.SetBool("Sprinting", true);
    }

    public override void UpdateState(Movement movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement, movement.Walk);
        else if (movement.dir.magnitude < 0.1f) ExitState(movement, movement.Idle);

        if (movement.vertInput < 0)
        {
            movement.currentMoveSpeed = movement.sprintBackSpeed;
        }
        else
        {
            movement.currentMoveSpeed = movement.sprintSpeed;
        }
    }

    void ExitState(Movement movement, MovementBaseState newState)
    {
        movement.anim.SetBool("Sprinting", false);
        movement.SwitchState(newState);
    }
}
