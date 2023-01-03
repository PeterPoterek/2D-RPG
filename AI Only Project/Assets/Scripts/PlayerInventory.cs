using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
 public List<WeaponItem> weaponInventory;

 public GameObject playerInventoryWindow;
 public GameObject playerEquipmentWindow;
 public bool playerInventoryActive;
 public GameObject inventorySlotPrefab;
 public List<GameObject> inventorySlots;

 public Dictionary<int, GameObject> button_map = new Dictionary<int, GameObject>();
 void Start()
 {

 }

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
   playerEquipmentWindow.SetActive(true);

   playerInventoryActive = true;
  }
  else if (Input.GetKeyDown(KeyCode.Tab) && playerInventoryActive == true)
  {
   playerInventoryWindow.SetActive(false);
   playerEquipmentWindow.SetActive(false);

   playerInventoryActive = false;
  }


 }
 public void AddItem(WeaponItem weaponItem)
 {
  weaponInventory.Add(weaponItem);
  GameObject newInventorySlot = Instantiate(inventorySlotPrefab, playerInventoryWindow.transform);
  newInventorySlot.SetActive(true);

  // Set the sprite of the new inventory slot to the sprite of the picked up item
  Image slotImage = newInventorySlot.GetComponent<Image>();
  slotImage.sprite = weaponItem.itemIcon;

  // Add the new inventory slot to the inventorySlots list
  inventorySlots.Add(newInventorySlot);


  // Add inventory slot to Dictionary
  for (int i = 0; i < weaponInventory.Count; i++)
  {
   button_map[i] = inventorySlots[i];
   Debug.Log(button_map[i] + " This slot is now assigned to item");


  }

 }
 public void RemoveItem(WeaponItem weaponItem)
 {
  weaponInventory.Remove(weaponItem);
 }

 public void InventorySlotPressed(int slotIndex)
 {
  WeaponItem weapon = weaponInventory[slotIndex];
  Debug.Log("Player pressed inventory slot " + slotIndex + " which contains the weapon " + weapon.name);
 }
}
