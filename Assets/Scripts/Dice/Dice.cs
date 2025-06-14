using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour, IDiceSelectable
{
    public DiceDefinition diceDefinition;
    public SpriteRenderer DiceFaceRenderer;
    private DiceFace currentFace;
    public Material DiceMaterial;
    public int diceValue => currentFace != null ? currentFace.value : 0;
    public InteractionState CurrentState = InteractionState.Deselected;



    private void Start()
    {
        DiceFaceRenderer = GetComponent<SpriteRenderer>();
        DiceMaterial = DiceFaceRenderer.material;
    }

    public void RollDice()
    {
        if (diceDefinition == null || diceDefinition.faces.Count == 0)
        {
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

    public void HandleSelection(InteractionState state)
    {
        CurrentState = state;
        switch (state)
        {
            case InteractionState.Hovered:
                // Handle hover state
                break;
            case InteractionState.Selected:
                Selected();
                break;
            case InteractionState.Deselected:
                DeSelected();
                break;
        }
    }

    public void Selected()
    {
        DiceMaterial.SetFloat("_Thickness", 0.05f);
    }

    public void DeSelected()
    {
        DiceMaterial.SetFloat("_Thickness", 0.0f);
    }
}