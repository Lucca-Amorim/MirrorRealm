using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public float force;
    bool freeze = false;
    public Patrol patrol;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            Rigidbody2D playerRb = trigger.transform.parent.gameObject.GetComponent<Rigidbody2D>();
            playerRb.AddForce(Vector2.up * force);
            freeze = true;
            StartCoroutine(FreezeEnemy());
        }
    }

    IEnumerator FreezeEnemy()
    {
        if(freeze == true)
        {
            SoundManagerScript.PlaySound("robotHit");
            patrol.speed = 0;
            yield return new WaitForSeconds(3);
            patrol.speed = 8;
        }
    }
}
