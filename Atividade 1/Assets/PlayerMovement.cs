using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;


    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        // pega velocidade de movimento do player
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // muda animação
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // ve se o player apertou o botao de pular
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        
    }

    void FixedUpdate()
    {
        // move o personagem
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
