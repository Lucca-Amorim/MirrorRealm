using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
public class PlayerMovement : MonoBehaviour{

    public float runSpeed = 40f;
	[Space]
    [Header("Self:")]
	PlayerControl controller;
    float horizontalMove = 0f;
    bool jump = false;
    public bool inversao;
    Animator animator;
	
    void Awake() {
        controller = gameObject.GetComponent<PlayerControl>();
        animator = GetComponent<Animator>();
    }
	void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("Jump", true);
        }
        if(horizontalMove !=0){
            animator.SetBool("Run", true);
        }else{
            animator.SetBool("Run", false);
        }
        
	}

	void FixedUpdate(){
        
        if(!inversao){
            controller.Move(horizontalMove * Time.fixedDeltaTime, false ,jump);
        }else{
            controller.Move((-1 * horizontalMove) * Time.fixedDeltaTime, false, jump);
        } 
        if(horizontalMove !=0){
            animator.SetBool("Run", true);
        }else{
            animator.SetBool("Run", false);
        }
		jump = false;
    }

}