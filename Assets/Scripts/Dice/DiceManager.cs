using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public static DiceManager Instance { get; private set; }

    public List<Dice> diceList = new();
    [SerializeField] private TextMeshProUGUI totalText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    //Receives a Dice object and registers it
    private void RegisterAllDice()
    {
        diceList.Clear();
        Dice[] allDice = FindObjectsOfType<Dice>();

        foreach (var dice in allDice)
        {
            diceList.Add(dice);
            Debug.Log("Registered Dice: " + dice.name);
        }
    }


    public void UnregisterDice(Dice dice)
    {
        diceList.Remove(dice);
    }

    // Rolls all dice in the scene and updates the total
    public void RollAll()
    {
        RefreshDiceList(); // scan for dice in scene

        foreach (var die in diceList)
        {
            die.RollDice();
        }

        UpdateTotal();
    }

    // This will update the dicelist to avoid issues with destroyed dice (Can cause dice total delay)
    private void RefreshDiceList()
    {
        diceList.Clear();
        Dice[] allDice = FindObjectsOfType<Dice>();
        diceList.AddRange(allDice);
    }
    
    //Just an update  
    public void UpdateTotal()
    {
        int total = 0;
        foreach (var die in diceList)
        {
            total += die.diceValue;
        }

        if (totalText != null)
            totalText.text = total.ToString();
    }
}