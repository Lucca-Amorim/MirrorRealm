using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fragmento : MonoBehaviour{
    
    int progress;
    void Awake(){
        try{
            StreamReader reader = new StreamReader("Assets\\fases.txt");
            //string temp = reader.ReadLine();
            //JnHearts = Int32.Parse(temp);
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
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Player")){
            StreamWriter writer = new StreamWriter("Assets\\fases.txt");
            writer.WriteLine(progress + 1);
            writer.Close();
            SceneManager.LoadScene(1);
            
        }
    }
}
