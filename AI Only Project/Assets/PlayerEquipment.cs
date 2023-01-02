using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
 public WeaponItem currentWeapon;
 public GameObject currentWeaponUI;
 PlayerInventory playerInventory;
 private void Awake()
 {
  playerInventory = GetComponent<PlayerInventory>();
 }
 void Start()
 {

 }

 void Update()
 {

 }

 void UpdatePlayerEquipment()
 {

 }

 public void EquipWeapon()
 {
  Debug.Log("Click");

 }
}
