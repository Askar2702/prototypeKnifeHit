using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Knife : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 20, ForceMode2D.Impulse);
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<Knife>())
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * -20, ForceMode2D.Impulse);
            GameManager.gameManager.LoseGame();
            return;
        }
        if (collision.transform.GetComponent<Target>() && GameManager.gameManager.gameState == GameState.Play)
        {
            transform.parent = collision.transform;
            GetComponent<Rigidbody2D>().isKinematic = true;
            collision.transform.GetComponent<Target>().PlayAnim();
        }
        
    }
}
