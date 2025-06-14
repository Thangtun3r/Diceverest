using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public int currentStamina = 0;
    public int maxStamina;
    public TMPro.TextMeshProUGUI currentStaminaText;

    private void Start()
    {
        currentStamina = maxStamina;
    }

    public void UseStamina(int amount)
    {
        currentStamina -= amount;
    }
    
    public void RestoreStamina(int amount)
    {
        currentStamina += amount;
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }
    private void Update()
    {
        if (currentStaminaText != null)
        {
            currentStaminaText.text = currentStamina.ToString();
        }
    }
}
