using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popInteractive : MonoBehaviour{
    GameObject player;
    GameObject texto;
    float range;


    void Start(){
        texto = gameObject.transform.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        //GameObject child = originalGameObject.transform.GetChild(0).gameObject;


    }
    void Update(){
        range = this.transform.position.x - player.transform.position.x; 

        if(range < 4.6f & range > -4.6f){
            texto.SetActive(true);
        }else{
            texto.SetActive(false);
        }

    }
}
