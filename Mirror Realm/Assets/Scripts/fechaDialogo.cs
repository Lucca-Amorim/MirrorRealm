using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fechaDialogo : MonoBehaviour{
    
    void Update(){
        if(Input.anyKeyDown){
            this.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
