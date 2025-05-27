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

    public void RollAll()
    {
        RefreshDiceList(); // scan for dice in scene

        foreach (var die in diceList)
        {
            die.RollDice();
        }

        UpdateTotal();
    }

    
    private void RefreshDiceList()
    {
        diceList.Clear();
        Dice[] allDice = FindObjectsOfType<Dice>();
        diceList.AddRange(allDice);
    }
    
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