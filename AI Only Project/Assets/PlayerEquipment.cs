using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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




 }



}
