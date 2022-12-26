using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 public float baseSpeed = 1f;
 public float sprintSpeed = 1.5f;

 public float dashPower = 10f;
 public float dashCooldown = 0;
 public float dashCooldownTime = 1f;
 public bool isDashing = false;
 public bool canDash = true;


 public Animator playerAnimator;
 Rigidbody2D playerRigidbody;
 public BoxCollider2D playerCollider;



 void Start()
 {
  playerAnimator = GetComponent<Animator>();
  playerRigidbody = GetComponent<Rigidbody2D>();
  playerCollider = GetComponent<BoxCollider2D>();


 }


 void FixedUpdate()
 {


  MovePlayer();
  HandleDashing();
 }




 void HandleDashing()
 {
  // Check if the player is pressing the dash button
  if (Input.GetKey(KeyCode.Space))
  {
   // Check if the dash is currently available
   if (!canDash)
   {
    // If the dash is not available, do nothing
    return;
   }
   // Get the current horizontal movement direction
   float horizontalMovement = Input.GetAxis("Horizontal");

   // If the player is moving horizontally, apply a force in the direction they are moving
   if (horizontalMovement != 0)
   {
    playerAnimator.SetTrigger("Roll");

    // Set the player's velocity in the direction they are moving
    playerRigidbody.velocity = new Vector2(horizontalMovement, 0) * dashPower;

    // Set the dash on cooldown
    canDash = false;
    dashCooldown = dashCooldownTime; // reset the dash cooldown
   }
  }
  //Decrement the dash cooldown timer
  dashCooldown -= Time.deltaTime;

  // If the dash cooldown has expired, set the dash to available
  if (dashCooldown <= 0)
  {
   canDash = true;
   dashCooldown = 0; // reset the dash cooldown timer to 0
  }
 }



 //Workaround player sprite not touching ground when rolling
 public void NormalCollider()
 {
  isDashing = false;
  playerCollider.size = new Vector2(0.2f, 0.37f);
 }
 public void DashCollider()
 {
  isDashing = true;
  playerCollider.size = new Vector2(0.2f, 0.2f);
 }



 public float ControlPlayerSpeed()
 {
  if (Input.GetKey(KeyCode.LeftShift))
  {

   float speed = baseSpeed + sprintSpeed;
   return speed;
  }
  else
  {

   float speed = baseSpeed;
   return speed;
  }
 }
 void FlipSpirte()
 {
  Vector3 currentScale = transform.localScale;
  float horizontalInput = Input.GetAxis("Horizontal");

  // Check if the sprite is moving left
  if (horizontalInput < 0)
  {
   // Flip the sprite by scaling it by -1 on the x-axis
   transform.localScale = new Vector3(-1, currentScale.y, currentScale.z);
  }
  else if (horizontalInput > 0)
  {
   // Otherwise, set the scale back to the original value
   transform.localScale = new Vector3(1, currentScale.y, currentScale.z);
  }
 }
 void CheckIfMoving()
 {

  float horizontalInput = Input.GetAxis("Horizontal");
  // Check if the player is moving
  if (horizontalInput != 0)
  {
   // Player is moving
   playerAnimator.SetBool("isMoving", true);
  }
  else
  {
   // Player is not moving
   playerAnimator.SetBool("isMoving", false);
  }
 }
 void MovePlayer()
 {

  float horizontalInput = Input.GetAxis("Horizontal");
  transform.position += new Vector3(horizontalInput, 0, 0) * ControlPlayerSpeed() * Time.deltaTime;

  FlipSpirte();
  CheckIfMoving();


 }



}
