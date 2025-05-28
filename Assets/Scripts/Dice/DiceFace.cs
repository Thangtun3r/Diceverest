using UnityEngine;

[CreateAssetMenu(menuName = "Dice/Face")]
public class DiceFace : ScriptableObject 
{
    public string label;
    public int value;
    public Sprite icon;
    public Color color = Color.white;
}
