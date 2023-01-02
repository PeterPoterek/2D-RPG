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

 PlayerEquipment playerEquipment;
 void Start()
 {
  playerEquipment = GetComponent<PlayerEquipment>();
 }


 void Update()
 {

 }

 public int CurrentAttackDamage()
 {
  if (playerEquipment.currentWeapon == null)
  {
   return 0;
  }
  return attackDamage * playerEquipment.currentWeapon.weaponDamage;
 }
}
