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

 PlayerEquipment playerEquipment;

 public Dictionary<int, GameObject> button_map = new Dictionary<int, GameObject>();

 private void Awake()
 {
  playerEquipment = GetComponent<PlayerEquipment>();
 }
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

   // Check if the inventory slot UI game object is not null
   if (inventorySlot != null)
   {
    // Check if the inventory slot UI game object is still active
    if (inventorySlot.activeSelf)
    {
     Image slotImage = inventorySlot.GetComponent<Image>();
     slotImage.sprite = item.itemIcon;
    }
   }
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

  // Add an OnClick event listener to the new inventory slot UI button
  Button button = newInventorySlot.GetComponent<Button>();
  int slotIndex = weaponInventory.Count - 1; // Pass the index of the added item as an argument
  button.onClick.AddListener(() => InventorySlotPressed(slotIndex));
 }
 public void RemoveItem(int index)
 {

  // Destroy the UI game object that represents the inventory slot
  GameObject inventorySlot = inventorySlots[index];
  Destroy(inventorySlot);

  // Remove the inventory slot UI game object from the inventorySlots list
  inventorySlots.RemoveAt(index);

  // Remove the item from the inventory
  weaponInventory.RemoveAt(index);

  // Update the indexes of the remaining items and inventory slots
  for (int i = index; i < weaponInventory.Count; i++)
  {
   inventorySlots[i].GetComponent<Button>().onClick.RemoveAllListeners();
   inventorySlots[i].GetComponent<Button>().onClick.AddListener(() => InventorySlotPressed(i));
   weaponInventory[i].index = i;
  }

 }

 public void InventorySlotPressed(int slotIndex)
 {
  if (slotIndex >= 0 && slotIndex < weaponInventory.Count)
  {
   // Check if the inventory slot UI game object is still active
   GameObject inventorySlot = inventorySlots[slotIndex];
   if (inventorySlot.activeSelf)
   {
    WeaponItem weapon = weaponInventory[slotIndex];
    Debug.Log("Player pressed inventory slot " + slotIndex + " which contains the weapon " + weapon.name);

    playerEquipment.EquipWeapon(weapon);
    // Remove the item and inventory slot UI game object from the inventory
    RemoveItem(slotIndex);
   }
  }
 }
}
