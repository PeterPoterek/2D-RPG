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
 Rigidbody2D enemyRigidbody;
 Animator enemyAnimator;

 public float speed = 0.5f;
 Vector3 moveDirection;
 public Transform target;
 void Start()
 {
  currentHealth = maxHealth;
  target = GameObject.FindWithTag("Player").transform;


  enemyAnimator = GetComponent<Animator>();
  enemyCollider = GetComponent<BoxCollider2D>();
  enemyRigidbody = GetComponent<Rigidbody2D>();
  playerCollider = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<BoxCollider2D>();
 }

 void Update()
 {


 }
 void FixedUpdate()
 {

  ChaseTarget();
 }

 void ChaseTarget()
 {
  // Calculate the position that the enemy should move to
  // by moving towards the player's position at the specified speed
  Vector2 targetPosition = Vector2.MoveTowards(
      enemyRigidbody.position,
      target.transform.position,
      speed * Time.deltaTime
  );

  // Move the enemy to the calculated position
  enemyRigidbody.MovePosition(targetPosition);
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
