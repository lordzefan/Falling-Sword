using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
 public int curentHealth, maxHealth;
 Animator animator;
 CharacterController characterController;

 public bool isDead;

    void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Start()
{
    curentHealth = maxHealth;
}

 public void TakeDamage(int damage)
 {
    curentHealth -= damage;
    if(isDead)return;
    if (curentHealth <=0)
    {
        OnDead();
    }
 }

 public void OnDead()
    {
        isDead = true;
       print("player mati"); 
       animator.Play("Death");
        characterController.enabled = false;
        GameManager.Instance.isGameOver = true;
    }
}
