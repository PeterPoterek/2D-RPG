using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{

 public Slider slider;
 public Image fillImage;


 PlayerHealth playerHealth;



 void Awake()
 {
  playerHealth = FindObjectOfType<PlayerHealth>();

  slider = GetComponentInChildren<Slider>();


 }




 public void SetMaxHealth(int maxHealth)
 {
  slider.maxValue = maxHealth;
  slider.value = maxHealth;
 }

 public void SetCurrentHealth(int currentHealth)
 {
  slider.value = currentHealth;


 }
}

