using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip danoSound, dano2Sound, jumpSound, enemyDeathSound, playerDeathSound, robotSound, houseSound;
    static AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        danoSound = Resources.Load<AudioClip>("dano3");
        dano2Sound = Resources.Load<AudioClip>("dano2");
        jumpSound = Resources.Load<AudioClip>("pulo");
        enemyDeathSound = Resources.Load<AudioClip>("mob_morte");
        playerDeathSound = Resources.Load<AudioClip>("morte");
        robotSound = Resources.Load<AudioClip>("robo_hit");
        houseSound = Resources.Load<AudioClip>("casas");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(danoSound);
                break;
            case "playerHit2":
                audioSrc.PlayOneShot(dano2Sound);
                break;
            case "jump":
                //audioSrc.PlayOneShot(jumpSound);
                break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "robotHit":
                audioSrc.PlayOneShot(robotSound);
                break;
            case "houseFalling":
                audioSrc.PlayOneShot(houseSound);
                break;
        }
    }
}
