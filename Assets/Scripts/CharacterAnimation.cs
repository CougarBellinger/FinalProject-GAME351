using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator playerAnim;
    public CharacterMovement playerMovement;
    public bool isBusy;

    void Update ()
    {

        if(!playerMovement.isWalking)
        {
            playerAnim.SetTrigger("idle");
        }

        //*******************************

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("walkFront");
            playerAnim.ResetTrigger("idle");
        }

        
        //*******************************

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("walkBack");
            playerAnim.ResetTrigger("idle");
        }


        //*******************************

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAnim.SetTrigger("walkLeft");
            playerAnim.ResetTrigger("idle");
        }


        //*******************************

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnim.SetTrigger("walkRight");
            playerAnim.ResetTrigger("idle");
        }

        //*******************************

        if (Input.GetMouseButton(0))
        {
            playerAnim.SetTrigger("shootRifle");
            playerAnim.ResetTrigger("idle");
        }

        //*******************************

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnim.SetTrigger("useSword");
            playerAnim.ResetTrigger("idle");
        }

        //*******************************

        if (Input.GetKeyDown(KeyCode.F))
        {
            playerAnim.SetTrigger("shootShotgun");
            playerAnim.ResetTrigger("idle");
        }

    }
}