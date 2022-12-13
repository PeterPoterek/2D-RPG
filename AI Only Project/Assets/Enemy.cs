using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public int maxHealth = 5;
 public int currentHealth = 0;
 // Start is called before the first frame update
 void Start()
 {
  currentHealth = maxHealth;
 }

 // Update is called once per frame
 void Update()
 {

 }

 public void TakeDamage(int damage)
 {
  if (currentHealth <= 0)
  {
   Death();
  }
  currentHealth = currentHealth - damage;

 }
 void Death()
 {
  Destroy(gameObject);
 }
}
