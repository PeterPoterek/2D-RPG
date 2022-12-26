using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
 public int maxHealth;
 public int currentHealth;
 public bool isDead;

 public PlayerMovement playerMovement;
 void Start()
 {
  currentHealth = maxHealth;
  playerMovement = GetComponent<PlayerMovement>();
 }

 void Update()
 {

 }
 public void TakeDamage(int damage)
 {
  if (isDead)
   return;
  if (playerMovement.isDashing)
   return;

  //enemyAnimator.SetTrigger("TakeDamage");
  currentHealth = currentHealth - damage;

  if (currentHealth <= 0)
  {
   Death();
  }

 }

 void Death()
 {
  Debug.Log("Player Dead");
 }
}
