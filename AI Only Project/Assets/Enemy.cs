using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public int maxHealth = 5;
 public int currentHealth = 0;
 public bool isDead;
 public bool isInRange;

 BoxCollider2D enemyCollider;
 public BoxCollider2D playerCollider;
 Rigidbody2D enemyRigidbody;
 Animator enemyAnimator;

 public float speed = 0.5f;
 public float attackRange = 1f;
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
  // Calculate the distance between the enemy and the target
  float distance = Vector3.Distance(transform.position, target.position);

  // Check if the distance is within the specified range
  if (distance <= attackRange)
  {
   // The enemy is within range
   if (!isInRange)
   {
    // The enemy has just entered the range, attack the player
    Attack();
   }
   isInRange = true;
  }
  else
  {
   // The enemy is outside the range, resume its movement
   ChaseTarget();
   isInRange = false;
  }
 }

 void FixedUpdate()
 {
  // Move the enemy towards the player
  ChaseTarget();
 }

 void Attack()
 {
  if (isDead)
   return;
  enemyAnimator.SetTrigger("Attack");
 }


 void ChaseTarget()
 {
  if (isDead)
   return;
  if (isInRange)
   return;

  Vector3 enemyPos = transform.position;
  Vector3 targetPos = target.position;

  // Calculate the distance to the target
  float distance = Vector3.Distance(enemyPos, targetPos);

  // Calculate the movement vector
  Vector3 moveDir = (targetPos - enemyPos).normalized;

  // Scale the movement vector by the speed and deltaTime
  moveDir *= speed * Time.deltaTime;

  // Move the enemy closer to the target
  enemyPos += moveDir;

  // Update the enemy's position
  transform.position = enemyPos;
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

 private void OnDrawGizmosSelected()
 {
  Gizmos.color = Color.red;
  Gizmos.DrawWireSphere(transform.position, attackRange);
 }
}
