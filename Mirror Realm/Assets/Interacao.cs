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

    void Start(){
        try{
            StreamReader reader = new StreamReader("Assets\\fases.txt");
            progress = Int32.Parse(reader.ReadLine());
            reader.Close();
        }catch(System.Exception){
            Debug.Log("erro ao ler os save, ver compatibilidade com o documento");
            StreamWriter writer = new StreamWriter("Assets\\fases.txt");
            writer.WriteLine(progress);
            writer.Close();
            throw;
        }
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            mexe();
        }
        Debug.Log(progress);
    }

    void mexe(){
        Collider2D[] hitEspelho = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, espelho);

        foreach(Collider2D espelho in hitEspelho){
            Debug.Log("hit" + espelho.name);
            switch(espelho.name){
                case "E1":
                    Debug.Log("entrando na fase 1");
                    if(progress == 0){
                        SceneManager.LoadScene(2);
                    }else{
                        Debug.Log("Fase ja completada");
                    }
                    break;
                case "E2":
                    if(progress == 1){
                        SceneManager.LoadScene(3);
                    }else if(progress < 1) {
                        Debug.Log("Sem Fragmento de espelho");
                    }else{
                        Debug.Log("Fase ja completada");
                    }
                    break;
                case "E3":
                    if(progress == 2){
                        SceneManager.LoadScene(4);
                    }else if(progress < 2) {
                        Debug.Log("Sem Fragmento de espelho");
                    }else{
                        Debug.Log("Fase ja completada");
                    }
                    break;
                default:
                    SceneManager.LoadScene(1);
                    break;
            }
        }
    }


    void OnDrawGizmosSelected(){
        if(attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}