using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
 public List<WeaponItem> weaponInventory;
 public WeaponItem currentWeapon;
 public GameObject playerInventoryWindow;
 public bool playerInventoryActive;
 public GameObject inventorySlot;
 // Start is called before the first frame update
 void Start()
 {

 }

 // Update is called once per frame
 void Update()
 {
  TogglePlayerInventory(playerInventoryActive);
 }
 void TogglePlayerInventory(bool isActive)
 {
  if (Input.GetKeyDown(KeyCode.Tab) && playerInventoryActive == false)
  {
   playerInventoryWindow.SetActive(true);
   playerInventoryActive = true;
  }
  else if (Input.GetKeyDown(KeyCode.Tab) && playerInventoryActive == true)
  {
   playerInventoryWindow.SetActive(false);
   playerInventoryActive = false;
  }


 }
 public void AddItem(WeaponItem weaponItem)
 {
  weaponInventory.Add(weaponItem);
  GameObject newInventorySlot = Instantiate(inventorySlot, playerInventoryWindow.transform);
  newInventorySlot.SetActive(true);

 }
 public void RemoveItem(WeaponItem weaponItem)
 {
  weaponInventory.Remove(weaponItem);
 }
}
