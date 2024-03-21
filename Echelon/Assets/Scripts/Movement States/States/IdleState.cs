using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(Movement movement)
    {

    }

    public override void UpdateState(Movement movement)
    {
        if (movement.dir.magnitude > 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement.SwitchState(movement.Sprint);
            }
            else
            {
                movement.SwitchState(movement.Walk);
            }
        }

        if (Input.GetKey(KeyCode.C))
        {
            movement.SwitchState(movement.Crouch);
        }
    }

}
