using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
 CharacterController characterController;
 float moveSpeed = 10f;
 // Start is called before the first frame update
 void Start()
 {
  characterController = GetComponent<CharacterController>();
 }

 // Update is called once per frame
 void Update()
 {
  // Get input from the horizontal axis (usually the left stick on a gamepad)
  float horizontalInput = Input.GetAxis("Horizontal");

  // Get input from the vertical axis (usually the left stick on a gamepad)
  float verticalInput = Input.GetAxis("Vertical");

  // Create a Vector3 object to store the movement direction
  Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

  // Normalize the movement direction so that the character doesn't move faster diagonally
  moveDirection = moveDirection.normalized;

  // Move the character in the direction specified by the movement direction
  characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
 }

}
