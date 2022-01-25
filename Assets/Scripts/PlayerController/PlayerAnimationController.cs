using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    public void PlayPlayerAnimation(string animationTag)
    {
        playerAnimator.Play(animationTag);
    }

    public PlayerState GetMoveState(float horizontalInput, float verticalInput)
    {
        #region Diagonal Movement
        if (horizontalInput < 0 && verticalInput > 0)
        {
            // walk left up
            playerAnimator.Play("player_walking_left_up");
            return PlayerState.IsMoving;
        }
        else

        if (horizontalInput > 0 && verticalInput > 0)
        {
            // walk right up
            playerAnimator.Play("player_walking_right_up");
            return PlayerState.IsMoving;
        }
        else

        if (verticalInput < 0 && horizontalInput < 0)
        {
            // walk left down
            playerAnimator.Play("player_walking_left_down");
            return PlayerState.IsMoving;
        }
        else

        if (verticalInput < 0 && horizontalInput > 0)
        {
            // walk right down
            playerAnimator.Play("player_walking_right_down");
            return PlayerState.IsMoving;
        }
        else
        #endregion


        #region Base Movement
        if (horizontalInput < 0)
        {
            // walk left
            playerAnimator.Play("player_walking_left");
            return PlayerState.IsMoving;
        }
        else 

        if (horizontalInput > 0)
        {
            // walk right
            playerAnimator.Play("player_walking_right");
            return PlayerState.IsMoving;
        }
        else 

        if (verticalInput < 0)
        {
            // walk down
            playerAnimator.Play("player_walking_down");
            return PlayerState.IsMoving;
        }
        else 

        if (verticalInput > 0)
        {
            // walk up
            playerAnimator.Play("player_walking_up");
            return PlayerState.IsMoving;
        }
        #endregion


        return PlayerState.IsStanding;
    }

    public void PlayLookAnimation(RotationSectorOnScreen sector)
    {
        switch(sector)
        {
            case RotationSectorOnScreen.Center:
                break;

        }
    }

}
