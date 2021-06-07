using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class cheat : MonoBehaviour{

    void Update(){
        if(Input.GetKey(KeyCode.LeftShift)){
            if(Input.GetKeyDown(KeyCode.Z)){
                SceneManager.LoadScene(2);
            }else if(Input.GetKeyDown(KeyCode.X)){
                SceneManager.LoadScene(3);
            }else if(Input.GetKeyDown(KeyCode.C)){
                SceneManager.LoadScene(4);
            }
        }
    }
}
