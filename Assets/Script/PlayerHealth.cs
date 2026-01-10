using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
 public int curentHealth, maxHealth;
 Animator animator;
 CharacterController characterController;
 public AudioClip swordHitSfx, deadSfx ;
 public AudioClip []playerHitSfx;
 AudioSource audioSource;
 public GameObject bloodVfx;
 public Transform bloodPoint;
 public Slider healthBar;
 private int CurnHealth
    {
        get => curentHealth;
        set
        {
            curentHealth = value;
            healthBar.value = value;
        }
    }

 public bool isDead;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Start()
{
    healthBar.maxValue = maxHealth;
    CurnHealth = maxHealth;
}

 public void TakeDamage(int damage)
 {
    Instantiate(bloodVfx, bloodPoint.position, Quaternion.identity);
    audioSource.PlayOneShot(swordHitSfx);
    animator.Play("Hit");
    CurnHealth -= damage;
    if(isDead)return;
    if (CurnHealth <=0)
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
        GameManager.Instance.IsGameOver();
    }
}
