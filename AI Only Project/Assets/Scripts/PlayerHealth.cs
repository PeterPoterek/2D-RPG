using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
 public int maxHealth;
 public int currentHealth;
 public bool isDead;

 PlayerHealthbar playerHealthbar;

 public PlayerMovement playerMovement;

 private void Awake()
 {
  playerMovement = GetComponent<PlayerMovement>();
  playerHealthbar = FindObjectOfType<PlayerHealthbar>();
 }
 void Start()
 {
  currentHealth = maxHealth;
  playerHealthbar.SetMaxHealth(maxHealth);

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
  playerHealthbar.SetCurrentHealth(currentHealth);

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
