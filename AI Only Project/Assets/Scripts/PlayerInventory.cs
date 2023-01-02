using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
 public List<WeaponItem> weaponInventory;
 public WeaponItem currentWeapon;
 public GameObject playerInventoryWindow;
 public bool playerInventoryActive;
 public GameObject inventorySlot;
 public List<GameObject> inventorySlots;
 // Start is called before the first frame update
 void Start()
 {

 }

 // Update is called once per frame
 void Update()
 {
  UpdatePlayerInventory();
  TogglePlayerInventory(playerInventoryActive);
 }
 void UpdatePlayerInventory()
 {
  for (int i = 0; i < weaponInventory.Count; i++)
  {
   if (i >= inventorySlots.Count)
   {
    // If the inventorySlots list is not large enough, break out of the loop
    break;
   }

   WeaponItem item = weaponInventory[i];
   GameObject inventorySlot = inventorySlots[i];
   Image slotImage = inventorySlot.GetComponent<Image>();
   slotImage.sprite = item.itemIcon;
  }
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

  // Set the sprite of the new inventory slot to the sprite of the picked up item
  Image slotImage = newInventorySlot.GetComponent<Image>();
  slotImage.sprite = weaponItem.itemIcon;

  // Add the new inventory slot to the inventorySlots list
  inventorySlots.Add(newInventorySlot);

 }
 public void RemoveItem(WeaponItem weaponItem)
 {
  weaponInventory.Remove(weaponItem);
 }
}
