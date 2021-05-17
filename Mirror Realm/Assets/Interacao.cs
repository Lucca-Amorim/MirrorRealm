using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interacao : MonoBehaviour{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask espelho;

    public int progress;
    
    public GameObject scene;

    void Start(){
        scene = GameObject.FindGameObjectWithTag("System");

        
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            mexe();
        }
        
    }

    void mexe(){
        Collider2D[] hitEspelho = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, espelho);
        foreach(Collider2D espelho in hitEspelho){
            SceneLoader sceneLoader = scene.GetComponent<SceneLoader>();
            sceneLoader.cena(espelho.name);

        }
    }


    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    


}