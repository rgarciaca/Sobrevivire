using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : BaseState
{
    public override void EnterState(PlayerController controller)
    {
        base.EnterState(controller);
    }

    public override void HandleMovement(Vector2 input)
    {
        base.HandleMovement(input);
        controllerReference.movement.HandleMovement(input);
    }

    public override void HandleCameraDirection(Vector3 input)
    {
        base.HandleCameraDirection(input);
        controllerReference.movement.HandleMovementDirection(input);
    }

    public override void Update()
    {
        base.Update();
        HandleMovement(controllerReference.input.MovementInputVector);
        HandleCameraDirection(controllerReference.input.MovementDirectionVector);
        if (!controllerReference.movement.IsGround())
        {
            /*if (fallingDelay > 0)
            {
                fallingDelay -= Time.deltaTime;
                return;
            }
            controllerReference.TransitionToState(controllerReference.fallingState);*/
        }
        else
        {
            //fallingDelay = defaultFallingDelay;
        }
    }
}
