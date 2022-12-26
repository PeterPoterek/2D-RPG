using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public int maxHealth = 5;
 public int currentHealth = 0;
 public bool isDead;
 public bool isMoving;
 public bool isInRange;
 public bool isAttacking;

 BoxCollider2D enemyCollider;
 public BoxCollider2D playerCollider;
 Rigidbody2D enemyRigidbody;
 Animator enemyAnimator;

 public float speed = 0.5f;
 public float attackRange = 1f;
 private float timer = 0.0f;
 public float attackDelay = 1.0f;

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
  HandleAttacking();
 }

 void HandleAttacking()
 {
  if (isDead)
   return;

  // Calculate the distance between the enemy and the target
  float distance = Vector3.Distance(transform.position, target.position);

  // Check if the distance is within the specified range
  if (distance <= attackRange)
  {
   // The enemy is within range
   if (!isInRange)
   {
    // The enemy has just entered the range, reset the timer
    enemyAnimator.SetBool("isMoving", false);
    timer = 0.0f;
   }
   isInRange = true;
  }
  else
  {
   // The enemy is outside the range
   if (!enemyAnimator.IsInTransition(0))
   {
    // The enemy is not in a transition between animations, stop the attack behavior and resume its movement
    timer = 0.0f;
    ChaseTarget();
    isInRange = false;
   }
  }

  // Update the timer
  timer += Time.deltaTime;

  // Check if it's time to attack
  if (timer >= attackDelay)
  {
   // It's time to attack, reset the timer and attack the player
   timer = 0.0f;
   Attack();
  }
 }

 void Attack()
 {
  enemyAnimator.SetTrigger("Attack");
 }


 void ChaseTarget()
 {
  if (isDead)
   return;
  if (isInRange)
   return;
  if (isAttacking)
   return;

  enemyAnimator.SetBool("isMoving", true);
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

  if (moveDir.x > 0)
  {
   //Moving Right
   transform.localScale = new Vector3(0.8f, 0.8f, 1);
  }
  else
  {
   //Moving Left
   transform.localScale = new Vector3(-0.8f, 0.8f, 1);


  }


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

 public void SetAttackToTrue()
 {
  isAttacking = true;
 }
 public void SetAttackToFalse()
 {
  isAttacking = false;
 }

 private void OnDrawGizmosSelected()
 {
  Gizmos.color = Color.red;
  Gizmos.DrawWireSphere(transform.position, attackRange);
 }
}
