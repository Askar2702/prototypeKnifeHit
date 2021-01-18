using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnife : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject knife;
    private GameObject _knife;

    

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.gameState != GameState.Play) return;
        if(Input.GetMouseButtonDown(0) || Input.touchCount < 0)
        {
            _knife = Instantiate(knife, transform.position, Quaternion.identity);
        }
    }

    
}
