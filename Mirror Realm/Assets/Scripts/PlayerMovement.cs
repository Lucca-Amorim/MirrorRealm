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
    public bool inversao = false;
    public bool centoEOitenta = false;
    Animator animator;

    [Space]
    [Header("da outra classe:")]
	public Following queda;
    public quedaTeste segue;
    float tempo = -10;
    void Awake() {
        controller = gameObject.GetComponent<PlayerControl>();
        animator = GetComponent<Animator>();
    }

	void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(!inversao & Input.GetButtonDown("Jump")){
            SoundManagerScript.PlaySound("jump");
            jump = true;
            animator.SetBool("Jump", true);
        }else if(inversao & Input.GetButtonDown("Crounch") & !centoEOitenta){
            SoundManagerScript.PlaySound("jump");
            jump = true;
            animator.SetBool("Jump", true);
        }else if(inversao & centoEOitenta & Input.GetButtonDown("Jump")){
            SoundManagerScript.PlaySound("jump");
            jump = true;
            animator.SetBool("Jump", true);
        }
        if(horizontalMove != 0){
            animator.SetBool("Run", true);
        }else{
            animator.SetBool("Run", false);
        }
        tempo -= Time.deltaTime * 2;
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

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Trigger")){
            if(tempo < 0){
                queda.mover = !queda.mover;
                segue.comeco = !segue.comeco;
                Debug.Log("Comecou");
                tempo = 15f;
            }
        }
    }
}