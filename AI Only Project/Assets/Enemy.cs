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
 public bool canAttack;
 BoxCollider2D enemyCollider;
 public BoxCollider2D playerCollider;
 PlayerHealth playerHealth;
 Rigidbody2D enemyRigidbody;
 Animator enemyAnimator;

 public float moveSpeed = 0.5f;
 public float attackRange = 1f;
 private float timer = 0.0f;
 public float attackDelay = 1.0f;


 Vector3 moveDirection;
 public Transform target;

 public int attackDamage;
 void Start()
 {
  currentHealth = maxHealth;
  target = GameObject.FindWithTag("Player").transform;

  playerHealth = FindObjectOfType<PlayerHealth>();
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
  if (playerHealth.isDead)
   return;
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
    canAttack = true;
    // enemyAnimator.SetBool("isMoving", false);
    timer = 0.0f;
   }
   isInRange = true;

   // Check if the enemy is able to attack
   if (canAttack)
   {
    // The enemy is able to attack, update the timer and check if it's time to attack
    timer += Time.deltaTime;
    if (timer >= attackDelay)
    {
     // It's time to attack, reset the timer and attack the player
     timer = 0.0f;
     Attack();
    }
   }
  }
  else
  {
   enemyAnimator.SetBool("isMoving", true);

   // The enemy is outside the range
   if (!enemyAnimator.IsInTransition(0))
   {
    // The enemy is not in a transition between animations, stop the attack behavior and resume its movement
    timer = 0.0f;
    ChaseTarget();
    isInRange = false;
   }
  }
 }


 void Attack()
 {
  // Check if the player is within the attack range
  float distance = Vector3.Distance(transform.position, target.position);

  // Play the attack animation
  enemyAnimator.SetTrigger("Attack");
  canAttack = true;
 }


 void ChaseTarget()
 {
  if (isDead)
   return;
  if (isInRange)
   return;
  if (isAttacking)
   return;

  Vector3 enemyPos = transform.position;
  Vector3 targetPos = target.position;

  // Calculate the distance to the target
  float distance = Vector3.Distance(enemyPos, targetPos);

  // Calculate the movement vector
  Vector3 moveDir = (targetPos - enemyPos).normalized;

  // Scale the movement vector by the speed and deltaTime
  moveDir *= moveSpeed * Time.deltaTime;

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


  //enemyAnimator.SetTrigger("TakeDamage");
  currentHealth = currentHealth - damage;

  if (currentHealth <= 0)
  {
   Death();
  }

 }
 void Death()
 {

  isDead = true;
  enemyAnimator.SetTrigger("Dead");
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
 public void DamagePlayer()
 {
  // Check if the player is within the attack range
  float distance = Vector3.Distance(transform.position, target.position);
  if (distance <= attackRange)
  {
   // The player is within range, apply damage to the player
   PlayerHealth player = target.GetComponent<PlayerHealth>();
   player.TakeDamage(attackDamage);
  }
 }

 private void OnDrawGizmosSelected()
 {
  Gizmos.color = Color.red;
  Gizmos.DrawWireSphere(transform.position, attackRange);
 }
}
