using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

 public bool isDead;

 PlayerHealthbar playerHealthbar;

 public PlayerMovement playerMovement;
 PlayerStats playerStats;

 private void Awake()
 {
  playerStats = GetComponent<PlayerStats>();
  playerMovement = GetComponent<PlayerMovement>();
  playerHealthbar = FindObjectOfType<PlayerHealthbar>();
 }
 void Start()
 {
  playerStats.currentHealth = playerStats.maxHealth;
  playerHealthbar.SetMaxHealth(playerStats.maxHealth);

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


  playerStats.currentHealth = playerStats.currentHealth - damage;
  playerHealthbar.SetCurrentHealth(playerStats.currentHealth);

  if (playerStats.currentHealth <= 0)
  {
   Death();
  }

 }

 void Death()
 {
  Debug.Log("Player Dead");
 }
}
