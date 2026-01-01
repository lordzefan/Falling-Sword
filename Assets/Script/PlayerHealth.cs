using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
 public int curentHealth, maxHealth;

void Start()
{
    curentHealth = maxHealth;
}

 public void TakeDamage(int damage)
 {
    curentHealth -= damage;
    if (curentHealth <=0)
    {
        print("player mati");
    }
 }
}
