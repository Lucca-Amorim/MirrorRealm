using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralelo : MonoBehaviour{
    
    float tamanho, startpos;
    public GameObject cam;
    public SpriteRenderer foto;
    public GameObject bg1;
    public GameObject bg2;
    public GameObject bg3;
    float bgY, bgZ;


    void Start() {
        tamanho = foto.GetComponent<SpriteRenderer>().bounds.size.x;
        bgY = bg1.transform.position.y;
        bgZ = bg1.transform.position.z;
        bg1.transform.position = new Vector3(bg1.transform.position.x + tamanho, bgY, bgZ);
        bg2.transform.position = new Vector3(bg1.transform.position.x + tamanho, bgY, bgZ);
        bg3.transform.position = new Vector3(bg1.transform.position.x + tamanho*2, bgY, bgZ);
    }
    void FixedUpdate(){
        float temp = (cam.transform.position.x );
        if(temp - 10 > transform.position.x + tamanho * 3.5f){
            transform.position = new Vector3(transform.position.x + tamanho, 0, 1.5f);
        }else if(temp < transform.position.x + tamanho * 2.3f){
            transform.position = new Vector3(transform.position.x - tamanho, 0, 1.5f);
        }
    }

    void inverte(){
        tamanho *= -1;
    }

    void reposiciona(){
        bg1.transform.position = new Vector3(bg1.transform.position.x + tamanho, bgY, bgZ);
        bg2.transform.position = new Vector3(bg1.transform.position.x + tamanho, bgY, bgZ);
        bg3.transform.position = new Vector3(bg1.transform.position.x + tamanho*2, bgY, bgZ);
    }
}
