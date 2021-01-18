using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private GameObject appleSlices; // дольки яблок
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<Knife>())
        {
            GameManager.gameManager.AppleScore();
            var apl1 = Instantiate(appleSlices, transform.position, Quaternion.identity);
            apl1.GetComponent<Rigidbody2D>().AddForce(transform.right * Random.Range(2f, 10f) , ForceMode2D.Impulse);

            var apl2 = Instantiate(appleSlices, transform.position, Quaternion.Euler(0f, 0f, 180f));
            apl2.GetComponent<Rigidbody2D>().AddForce(-transform.right * Random.Range(2f, 10f) , ForceMode2D.Impulse);
            Destroy(this.gameObject);
        }
    }
}
