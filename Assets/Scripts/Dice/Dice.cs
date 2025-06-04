using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour {
    public DiceDefinition diceDefinition;
    public SpriteRenderer DiceFaceRenderer;

    private DiceFace currentFace;
    public int diceValue => currentFace != null ? currentFace.value : 0;

    private void Start()
    {
        DiceFaceRenderer = GetComponent<SpriteRenderer>();
    }

    public void RollDice() {
        if (diceDefinition == null || diceDefinition.faces.Count == 0) {
            return;
        }

        int index = Random.Range(0, diceDefinition.faces.Count);
        currentFace = diceDefinition.faces[index];

        UpdateUI();
    }

    private void UpdateUI() 
    {
        if (DiceFaceRenderer == null)
        {
            Debug.LogWarning("DiceFaceRenderer is not assigned on " + gameObject.name);
            return;
        }
        DiceFaceRenderer.sprite = currentFace.icon;
    }
}