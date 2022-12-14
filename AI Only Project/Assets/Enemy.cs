using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public int maxHealth = 5;
 public int currentHealth = 0;

 Animator enemyAnimator;
 void Start()
 {
  currentHealth = maxHealth;
  enemyAnimator = GetComponent<Animator>();
 }

 void Update()
 {

 }

 public void TakeDamage(int damage)
 {
  if (currentHealth <= 0)
  {
   Death();
  }

  enemyAnimator.SetTrigger("TakeDamage");
  currentHealth = currentHealth - damage;

 }
 void Death()
 {
  Destroy(gameObject);
 }
}
