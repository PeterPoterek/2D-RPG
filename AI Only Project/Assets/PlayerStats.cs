using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
 [Header("Health")]
 public int maxHealth;
 public int currentHealth;
 [Header("Stamina")]
 public int staminaLevel;
 [Header("AttackDamage")]
 public int attackDamage;
 [Header("Defensive")]
 public int Arrmor;
 public int magicResist;

 PlayerInventory playerInventory;
 void Start()
 {
  playerInventory = GetComponent<PlayerInventory>();
 }


 void Update()
 {

 }

 public int CurrentAttackDamage()
 {

  return attackDamage * playerInventory.currentWeapon.weaponDamage;
 }
}
