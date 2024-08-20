using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator playerAnim;
    public CharacterMovement playerMovement;

    // void Start ()
    // {
        
    // }

    void Update ()
    {

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

        

    }
}