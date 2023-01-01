using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
 public SpriteRenderer itemSprite;
 public WeaponItem item;
 private void Start()
 {
  itemSprite = GetComponent<SpriteRenderer>();
  itemSprite.sprite = item.itemIcon;
 }


 private void OnTriggerEnter2D(Collider2D other)
 {
  if (other.tag == "Player")
  {
   other.GetComponent<PlayerInventory>().AddItem(item);
   Destroy(gameObject);
  }
 }
}
