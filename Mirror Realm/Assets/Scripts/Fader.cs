using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Fader : MonoBehaviour{
    bool fadeIn;
    bool fadeOut;
    float alpha = 1;
    public float fadeSpeed = 1;
    Action callback;
    int nextScene;
    Image image;
    void Start(){
        fadeIn = true;
        fadeOut = false;
        image = GetComponent<Image>();
    }
    void Update(){
        if(fadeOut){
            alpha += fadeSpeed * Time.deltaTime;
            if(alpha > 1){
                alpha = 1;
                fadeOut = false;
                if(callback != null)
                    callback();
            }
        }

        if(fadeIn){
            alpha -= fadeSpeed * Time.deltaTime;
            if(alpha < 0){
                alpha = 0;
                fadeIn = false;
            }
        }
        image.color = new Color(0, 0, 0, alpha);
    }
    public void ExitScene(int scene, Action callback){
        fadeOut = true;
        fadeIn = false;
        nextScene = scene;
        this.callback = callback;
        image.raycastTarget = true;
    }
    public void ExitScene(int scene){
        ExitScene(scene, null);
    }
    public void saida(){
        fadeOut = true;
        fadeIn = false;
        if(fadeOut){
            alpha += fadeSpeed * Time.deltaTime;
            if(alpha > 1){
                alpha = 1;
                fadeOut = false;
                
                if(callback != null)
                    callback();
            }
        }

        if(fadeIn){
            alpha -= fadeSpeed * Time.deltaTime;
            if(alpha < 0){
                alpha = 0;
                fadeIn = false;
            }
        }
        image.color = new Color(0, 0, 0, alpha);
    }
}
