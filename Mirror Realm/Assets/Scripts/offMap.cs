using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offMap : MonoBehaviour{
    
    void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("fazer o player morrer");
        GameObject play = other.gameObject;
        play.transform.position = new  Vector3(3.4f, 0.3f, 0);
    }
    
}
