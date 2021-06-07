using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevIA : MonoBehaviour{

    public float speed;
    public float distance;
    public Transform target;
    bool movRight;
    
    Transform groundDet;
    Transform groundDet2;


    void Awake() {
        groundDet = this.gameObject.transform.Find("Chao");
        groundDet2 = this.gameObject.transform.Find("Chao2");
    }
    
    void Update(){
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        mexe();
    }
    void mexe(){
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDet.position, Vector2.down, distance);
        RaycastHit2D groundInfo2 = Physics2D.Raycast(groundDet2.position, Vector2.down, distance);
        if((groundInfo.collider == false) || (groundInfo2.collider == false)){
            speed *= -1;
        }
    }

    void pursue(){
        float distanceP = Vector2.Distance (transform.position, target.position);

        if(distanceP <= 15 && distanceP + 3 > distanceP){
            speed = -speed;
        }else{
            speed = +speed;
        }

    }

    void OnDrawGizmosSelected(){
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 15);
        }

}
