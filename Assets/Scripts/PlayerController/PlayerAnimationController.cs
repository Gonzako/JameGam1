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

    public void DecideWalkingAnimation(float horizontalInput, float verticalInput)
    {
        if (horizontalInput < 0 && verticalInput > 0)
        {
            // walk left up
            Debug.Log("player_walking_left_up");
            playerAnimator.Play("player_walking_left_up");
        }
        else

        if (horizontalInput > 0 && verticalInput > 0)
        {
            // walk right up
            Debug.Log("player_walking_right_up");
            playerAnimator.Play("player_walking_right_up");
        }
        else

        if (verticalInput < 0 && horizontalInput < 0)
        {
            // walk left down
            Debug.Log("player_walking_left_down");
            playerAnimator.Play("player_walking_left_down");
        }
        else

        if (verticalInput < 0 && horizontalInput > 0)
        {
            // walk right down
            Debug.Log("player_walking_right_down");
            playerAnimator.Play("player_walking_right_down");
        }else

        #region Base Movement
        if (horizontalInput < 0)
        {
            // walk left
            Debug.Log("player_walking_left");
            playerAnimator.Play("player_walking_left");
        }else 

        if (horizontalInput > 0)
        {
            // walk right
            Debug.Log("player_walking_right");
            playerAnimator.Play("player_walking_right");
        }else 

        if (verticalInput < 0)
        {
            // walk down
            Debug.Log("player_walking_down");
            playerAnimator.Play("player_walking_down");
        }else 

        if (verticalInput > 0)
        {
            // walk up
            Debug.Log("player_walking_up");
            playerAnimator.Play("player_walking_up");
        }
        #endregion

        #region Diagonal Movement
        
        #endregion
    }

}
