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
	
    void Start() {
        controller = gameObject.GetComponent<PlayerControl>();
    }
	void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }
	}

	void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false ,jump);
		jump = false;
    }




}