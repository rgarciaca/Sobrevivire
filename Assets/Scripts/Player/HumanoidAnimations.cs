using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedCustomizableSystem;

public class HumanoidAnimations : MonoBehaviour
{
   private Animator animator;

    private void Awake() {
        animator = GetComponent<CharacterCustomization>().animators[0];
        animator = GetComponent<Animator>();
    }

    /*public void TriggerLandingAnimation()
    {
        animator.SetTrigger("Land");
    }

    public void ResetTriggerLandingAnimation()
    {
        animator.ResetTrigger("Land");
    }

    public void TriggerJumpAnimation()
    {
        animator.SetTrigger("Jump");
    }*/

    /*public void SetMovementFloat(float value)
    {
        
        //animator.SetFloat("move", value);
    }*/
    
    public void SetMovement(bool value)
    {
        
        animator.SetBool("walk", value);
    }

    /*public void TriggerFallAnimation()
    {
        animator.SetTrigger("Fall");
    }*/

    public float SetCorrectAnimation(float desiredRotationAngle, int angleThreshold, int inputVerticalDirection)
    {
        float currentAnimationSpeed = animator.GetFloat("move");
        if (desiredRotationAngle > angleThreshold || desiredRotationAngle < -angleThreshold)
        {
            if (Mathf.Abs(currentAnimationSpeed) < .2f)
            {
                currentAnimationSpeed += inputVerticalDirection * Time.deltaTime * 2;
                currentAnimationSpeed = Mathf.Clamp(currentAnimationSpeed, -0.2f, 0.2f);
            }
            
            //SetMovementFloat(currentAnimationSpeed);
        }
        else
        {
            if (currentAnimationSpeed < 1)
            {
                currentAnimationSpeed += inputVerticalDirection * Time.deltaTime * 2;
            }
            //SetMovementFloat(Mathf.Clamp(currentAnimationSpeed, -1, 1));
        }
        SetMovement(true);
        return Mathf.Abs(currentAnimationSpeed);
    }
}
