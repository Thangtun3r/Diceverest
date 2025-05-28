using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dice/Definition")]
public class DiceDefinition : ScriptableObject 
{
    public List<DiceFace> faces;
}