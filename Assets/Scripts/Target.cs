using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Target : MonoBehaviour
{
    public event Action notyfi;
    [SerializeField] private float speedRotate;
    [SerializeField] private GameObject _logs;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if(GameManager.gameManager.gameState == GameState.Win)
            animator.Play("SPawn");
    }
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 50f * Time.deltaTime * speedRotate));
    }

    public void PlayAnim()
    {
        animator.enabled = true;
        animator.Play("Target");
        notyfi?.Invoke();
    }

    public void NextGame()
    {
        GameManager.gameManager.NextLvl();
    }

    public void instanceLogs()
    {
        Instantiate(_logs, transform.position, Quaternion.identity);
    }
   
}
