using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomped : MonoBehaviour
{
    public float force;
    bool stomped = false;
    
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
            stomped = true;
            Destroy();
        }
    }

    void Destroy()
    {
        if(stomped == true)
        {
            SoundManagerScript.PlaySound("enemyHit");
            Destroy(transform.parent.gameObject);
        }
    }
}
