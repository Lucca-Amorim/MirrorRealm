using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testeeee : MonoBehaviour{
    Rigidbody2D corpo;

    void Start(){
        corpo = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.G)) corpo.AddForce(new Vector2(-222,0));
        if(Input.GetKeyDown(KeyCode.H)) corpo.AddForce(new Vector2(222,0));
    }
}
