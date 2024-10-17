using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bran"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BrownRice"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("CrackRice"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Husk"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Paddy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("RiceFlour"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Spiklet"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Stalk"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("StandardRice"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PremiumRice"))
        {
            Destroy(collision.gameObject);
        }
    }
}
