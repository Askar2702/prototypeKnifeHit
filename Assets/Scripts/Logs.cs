using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(-20f, 20f), ForceMode2D.Impulse);
        Destroy(gameObject, 3f);
    }

    
}
