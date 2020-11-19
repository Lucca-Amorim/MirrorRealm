using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quedaTeste : MonoBehaviour{

    public GameObject Casa1;
    public GameObject Casa2;
    public GameObject Casa3;
    public GameObject Casa4;
    public GameObject Predio;
    public GameObject Arvore;

    GameObject Obj;
    float tempo = 0.4f;

    public bool comeco = false;


    private void Update(){
        if(comeco){
            if(tempo < 0){
                trocaPrefab();
                GameObject apagar = Instantiate(Obj, transform.position, Quaternion.identity);
                Destroy(apagar, 10f);
                tempo = 0.4f;
            }
            tempo -= Time.deltaTime;
        }
    }

    void trocaPrefab(){
        int random = Random.Range(0,5);
        switch(random){
            case 0:
                Obj = Casa1;
                break;
            case 1:
                Obj = Casa2;
                break;
            case 2:
                Obj = Casa3;
                break;
            case 3:
                Obj = Casa4;
                break;
            case 4:
                Obj = Predio;
                break;
            case 5:
                Obj = Arvore;
                break;
            default:
                Obj = Casa1;
                break;
        }
    }
}
