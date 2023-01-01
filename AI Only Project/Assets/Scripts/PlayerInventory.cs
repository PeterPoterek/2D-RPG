using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
 public List<WeaponItem> weaponInventory;
 public WeaponItem currentWeapon;
 // Start is called before the first frame update
 void Start()
 {

 }

 // Update is called once per frame
 void Update()
 {

 }

 public void AddItem(WeaponItem weaponItem)
 {
  weaponInventory.Add(weaponItem);
 }
 public void RemoveItem(WeaponItem weaponItem)
 {
  weaponInventory.Remove(weaponItem);
 }
}
