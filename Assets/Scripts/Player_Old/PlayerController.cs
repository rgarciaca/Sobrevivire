using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerInput input;
    public HumanoidAnimations agentAnimations;

    BaseState currentState;
    public readonly BaseState movementState = new MovementState();

    // Start is called before the first frame update
    void OnEnable()
    {
        movement = GetComponent<PlayerMovement>();
        input = GetComponent<PlayerInput>();
        agentAnimations = GetComponent<HumanoidAnimations>();

        currentState = movementState;
        currentState.EnterState(this);
    }

    private void Update() {
        currentState.Update();
    }

    private void OnDisable() {
        //input.OnJump -= HandleJump;
        //input.OnJump -= currentState.HandleJumpInput;
    }

    public void TransitionToState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
