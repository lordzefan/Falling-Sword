using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
 public int curentHealth, maxHealth;
 Animator animator;
 CharacterController characterController;
 public AudioClip swordHitSfx;
 public AudioClip []playerHitSfx;
 public AudioClip deadSfx;
 AudioSource audioSource;
 public GameObject bloodVfx;
 public Transform bloodPoint;

 public bool isDead;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Start()
{
    curentHealth = maxHealth;
}

 public void TakeDamage(int damage)
 {
    Instantiate(bloodVfx, bloodPoint.position, Quaternion.identity);
    audioSource.PlayOneShot(swordHitSfx);
    animator.Play("Hit");
    curentHealth -= damage;
    if(isDead)return;
    if (curentHealth <=0)
    {
        audioSource.PlayOneShot(deadSfx);
        OnDead();
    }
        else
        {
           audioSource.PlayOneShot(playerHitSfx[Random.Range(0, playerHitSfx.Length)]) ;
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
