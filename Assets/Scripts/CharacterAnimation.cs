using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator playerAnim;
    public CharacterMovement playerMovement;

    private float normalSpeed = 1f;
    private float runSpeed = 1.5f;

    void Update()
    {

        if (!playerMovement.isMoving)
        {
            playerAnim.SetTrigger("idle");
        }
        else
        {
            playerAnim.ResetTrigger("idle");
        }

        //*******************************

        if (Input.GetKey(KeyCode.W))
        {
            playerAnim.SetTrigger("walkFront");
            playerAnim.ResetTrigger("idle");
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("walkFront");
        }


        //*******************************

        if (Input.GetKey(KeyCode.S))
        {
            playerAnim.SetTrigger("walkBack");
            playerAnim.ResetTrigger("idle");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("walkBack");
        }

        //*******************************

        if (Input.GetKey(KeyCode.A))
        {
            playerAnim.SetTrigger("walkLeft");
            playerAnim.ResetTrigger("idle");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.ResetTrigger("walkLeft");
        }

        //*******************************

        if (Input.GetKey(KeyCode.D))
        {
            playerAnim.SetTrigger("walkRight");
            playerAnim.ResetTrigger("idle");
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.ResetTrigger("walkRight");
        }

        //*******************************

        if (Input.GetMouseButtonDown(0))
        {
            playerAnim.SetTrigger("shootRifle");
            playerAnim.ResetTrigger("idle");
        }

        if (Input.GetMouseButtonUp(0))
        {
            playerAnim.ResetTrigger("shootRifle");
        }

        //*******************************

        if (Input.GetKey(KeyCode.Q))
        {
            playerAnim.SetTrigger("useSword");
            playerAnim.ResetTrigger("idle");
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            playerAnim.ResetTrigger("useSword");
        }

        //*******************************

        if (Input.GetKey(KeyCode.F))
        {
            playerAnim.SetTrigger("shootShotgun");
            playerAnim.ResetTrigger("idle");
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            playerAnim.ResetTrigger("shootShotgun");
        }

        //*******************************

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("rifleAttack") ||
                !playerAnim.GetCurrentAnimatorStateInfo(0).IsName("shotgunAttack") ||
                !playerAnim.GetCurrentAnimatorStateInfo(0).IsName("swordAttack") ||
                !playerAnim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                playerAnim.speed = runSpeed;
            }
        }
        else
        {
            playerAnim.speed = normalSpeed;
        }


    }
}