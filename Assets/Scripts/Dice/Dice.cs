using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public TextMeshProUGUI diceText;
    public int diceValue = 1;

    /*
    private void OnEnable()
    {
        DiceManager.Instance?.RegisterDice(this);
    }

    private void OnDisable()
    {
        DiceManager.Instance?.UnregisterDice(this);
    }
    */

    
    
    public void RollDice()
    {
        diceValue = UnityEngine.Random.Range(1, 7);
        UpdateDiceText();
    }
    
    private void UpdateDiceText()
    {
        if (diceText != null)
        {
            diceText.text = diceValue.ToString();
        }
        else
        {
            Debug.LogWarning("Dice text is not assigned.");
        }
    }
}
