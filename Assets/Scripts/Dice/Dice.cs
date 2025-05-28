using TMPro;
using UnityEngine;

public class Dice : MonoBehaviour {
    public DiceDefinition diceDefinition;
    public TextMeshProUGUI diceText;

    private DiceFace currentFace;
    public int diceValue => currentFace != null ? currentFace.value : 0;


    public void RollDice() {
        if (diceDefinition == null || diceDefinition.faces.Count == 0) {
            return;
        }

        int index = Random.Range(0, diceDefinition.faces.Count);
        currentFace = diceDefinition.faces[index];

        UpdateUI();
    }

    private void UpdateUI() {
        if (diceText != null && currentFace != null) {
            diceText.text = currentFace.label;
            diceText.color = currentFace.color;
        }
    }
}