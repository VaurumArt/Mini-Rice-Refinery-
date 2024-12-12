using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      
        // Check if the colliding object is tagged "Spiklet"
        if (collision.gameObject.CompareTag("BasicMillerHole"))
        {
            Invoke("Destory", 0f);
        }
    }
    void Destory()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
