using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int hP = 3;

    float timer;
    bool invencible = false;

    Material mWhite;
    Material mDefault;
    SpriteRenderer sRend;
    public PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
        mDefault = sRend.material;
        mWhite = Resources.Load("mWhite", typeof(Material)) as Material;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            invencible = false;
        }
        if (hP <= 0)
        {
            pauseMenu.GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") && invencible == false)
        {
            Hurt();
            --hP;

            switch (hP)
            {
                case 2:
                    SoundManagerScript.PlaySound("playerHit");
                    break;
                case 1:
                    SoundManagerScript.PlaySound("playerHit2");
                    break;
                case 0:
                    SoundManagerScript.PlaySound("playerDeath");
                    break;
            }
        }
    }

    void Hurt()
    {
        StartCoroutine("Flash");
        Invencible();
    }

    void Invencible()
    {
        timer = 1;
        if (timer > 0)
        {
            invencible = true;
        }
    }

    IEnumerator Flash()
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.25f);
            sRend.material = mWhite;
            Invoke("ResetMaterial", 0.15f);
        }
    }

    void ResetMaterial()
    {
        sRend.material = mDefault;
    }
}
