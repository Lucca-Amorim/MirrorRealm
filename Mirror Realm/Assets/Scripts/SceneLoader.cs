using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneLoader : MonoBehaviour{
    public AudioMixer mixer;
    public LayerMask espelho;
    public int progress;
    public Fader fader;

    void Start(){
        try{
            StreamReader reader = new StreamReader("Assets\\fases.txt");
            progress = Int32.Parse(reader.ReadLine());
            reader.Close();
        }catch(System.Exception){
            Debug.Log("erro ao ler os save, ver compatibilidade com o documento");
            StreamWriter writer = new StreamWriter("Assets\\fases.txt");
            writer.WriteLine(progress);
            writer.Close();
            throw;
        }
    }

    public void cena(string espelho){
        switch(espelho){
            case "E1":
                Debug.Log("entrando na fase 1");
                if(progress == 0){
                    fader.saida();
                    SceneManager.LoadSceneAsync(2);
                }else{
                    Debug.Log("Fase ja completada");
                }
                break;
            case "E2":
                if(progress == 1){
                    fader.saida();
                    SceneManager.LoadSceneAsync(3);
                }else if(progress < 1) {
                    Debug.Log("Sem Fragmento de espelho");
                }else{
                    Debug.Log("Fase ja completada");
                }
                break;
            case "E3":
                if(progress == 2){
                    fader.saida();
                    SceneManager.LoadSceneAsync(4);
                }else if(progress < 2) {
                    Debug.Log("Sem Fragmento de espelho");
                }else{
                    Debug.Log("Fase ja completada");
                }
                break;
            default:
                SceneManager.LoadSceneAsync(0);
                break;
        }
    }

    public void LoadGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void SetLevel(float sliderValue){
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }


}
