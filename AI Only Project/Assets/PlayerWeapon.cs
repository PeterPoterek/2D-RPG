using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
 void OnTriggerEnter2D(Collider2D collider)
 {
  // Check if the collider has the "Enemy" tag
  if (collider.tag == "Enemy")
  {
   // Do something when the enemy collides with the trigger
  }
 }
}
