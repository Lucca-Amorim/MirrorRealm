using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour{

    public bool mover = false;
    public GameObject player;
    void Start(){
        this.transform.position = player.transform.position;
    }

    void Update(){
        if(mover){
            transform.position = new Vector3(transform.position.x, player.transform.position.y , 0f);
            transform.position += new Vector3(Time.deltaTime * 12f, 0f, 0f);
        }else{
            transform.position = player.transform.position;
        }
    }
}
