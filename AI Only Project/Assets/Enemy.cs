using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public int maxHealth = 5;
 public int currentHealth = 0;
 public bool isDead;

 BoxCollider2D enemyCollider;
 public BoxCollider2D playerCollider;

 Animator enemyAnimator;
 void Start()
 {
  currentHealth = maxHealth;
  enemyAnimator = GetComponent<Animator>();
  enemyCollider = GetComponent<BoxCollider2D>();
  playerCollider = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<BoxCollider2D>();
 }

 void Update()
 {

 }

 public void TakeDamage(int damage)
 {
  if (isDead)
   return;


  enemyAnimator.SetTrigger("TakeDamage");
  currentHealth = currentHealth - damage;

  if (currentHealth <= 0)
  {
   Death();
  }

 }
 void Death()
 {

  isDead = true;
  enemyAnimator.SetBool("isDead", isDead);
  Physics2D.IgnoreCollision(playerCollider, enemyCollider);
  // Destroy(gameObject);
 }
}
