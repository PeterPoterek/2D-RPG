using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
 Animator playerAnimator;
 PlayerMovement playerMovement;
 Rigidbody2D playerRigidbody;



 public bool isAttacking;
 public bool canAttack = true;
 public float timeBetweenAttacks;
 public float maximumTimeBetweenAttacks;

 public Transform attackPosition;
 public float attackRange;
 public LayerMask EnemyLayer;
 public int damage;

 private void Start()
 {
  playerAnimator = GetComponent<Animator>();
  playerMovement = FindObjectOfType<PlayerMovement>();
  playerRigidbody = GetComponent<Rigidbody2D>();

  timeBetweenAttacks = maximumTimeBetweenAttacks;
 }
 void Update()
 {
  HandleAttackCooldown();
 }

 void HandleAttack()
 {
  if (playerMovement.isDashing == true)
   return;


  if (Input.GetKey(KeyCode.E))
  {

   isAttacking = true;
   canAttack = false;

   if (isAttacking)
   {

    HandleWeaponCollision();
    playerAnimator.SetTrigger("Attack");
    isAttacking = false;
   }
  }
 }

 void HandleWeaponCollision()
 {
  Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, EnemyLayer);
  foreach (Collider2D enemy in enemies)
  {
   enemy.GetComponent<Enemy>().TakeDamage(damage);

  }
 }
 void HandleAttackCooldown()
 {
  if (canAttack == false)
  {
   timeBetweenAttacks -= Time.deltaTime;

  }

  if (canAttack)
  {
   HandleAttack();
  }

  if (timeBetweenAttacks < 0)
  {
   timeBetweenAttacks = maximumTimeBetweenAttacks;

   canAttack = true;
  }
 }

 public void EnableMovement()
 {
  playerMovement.enabled = true;
 }
 public void DisableMovement()
 {
  playerMovement.enabled = false;
 }
 void OnDrawGizmosSelected()
 {
  Gizmos.color = Color.red;
  Gizmos.DrawWireSphere(attackPosition.position, attackRange);
 }









}
