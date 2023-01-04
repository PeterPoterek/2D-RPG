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


 void UpdatePlayerEquipment()
 {

 }

 public void EquipWeapon(WeaponItem weaponToEquip)
 {
  currentWeapon = weaponToEquip;
  Image slotImage = currentWeaponUI.GetComponent<Image>();
  slotImage.sprite = weaponToEquip.itemIcon;


 }



}
