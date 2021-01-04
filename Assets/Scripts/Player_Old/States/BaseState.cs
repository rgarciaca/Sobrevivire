using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected PlayerController controllerReference;

    public virtual void EnterState(PlayerController controller)
    {
        this.controllerReference = controller;
    }

    public virtual void HandleMovement(Vector2 input) { }

    public virtual void HandleCameraDirection(Vector3 input) { }

    public virtual void Update() { }
}
