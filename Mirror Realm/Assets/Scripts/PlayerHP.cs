using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    int hP = 3;

    float timer;
    bool invencible = false;

    Material mWhite;
    Material mDefault;
    SpriteRenderer sRend;

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
            Time.timeScale = 0;
            Debug.Log("Morri");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") && invencible == false)
        {
            Hurt();
            --hP;
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
