using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogo : MonoBehaviour{
    float tempo = 2f;
    bool primeira = true;
    bool segunda = true;
    public GameObject dialogo1;
    public GameObject dialogo2;
    bool termino;
    void Update(){
        if(tempo < 0){
            Time.timeScale = 0f;
            if(primeira){
                dialogo1.SetActive(true);
                primeira = false;
                tempo = 3f;
            }
            else if(segunda){
                dialogo2.SetActive(true);
                segunda = false;
            }
            else {
                termino = true;
                Time.timeScale = 1f;
            }
        }
        if(!termino)tempo -= Time.deltaTime;
    }
}
