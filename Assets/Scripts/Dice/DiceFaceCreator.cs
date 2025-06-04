using UnityEditor;
using UnityEngine;
using System.IO;

public class DiceFaceCreator : EditorWindow
{
    private int numberOfFaces = 6;
    private string baseName = "Face";
    private Color color = Color.white;
    private Sprite icon;
    private string diceDefName = "NewDiceDefinition";

    [MenuItem("DiceTools/Create Dice Faces & Definition")]
    public static void ShowWindow()
    {
        GetWindow<DiceFaceCreator>("Dice Face Generator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Dice Face Generator", EditorStyles.boldLabel);

        numberOfFaces = EditorGUILayout.IntField("Number of Faces", numberOfFaces);
        baseName = EditorGUILayout.TextField("Base Name", baseName);
        color = EditorGUILayout.ColorField("Face Color", color);
        icon = (Sprite)EditorGUILayout.ObjectField("Icon", icon, typeof(Sprite), false);
        diceDefName = EditorGUILayout.TextField("Dice Definition Name", diceDefName);

        if (GUILayout.Button("Generate"))
        {
            CreateDiceFacesAndDefinition();
        }
    }

    private void CreateDiceFacesAndDefinition()
    {
        string folderPath = $"Assets/Dice/{diceDefName}";
        Directory.CreateDirectory(folderPath);

        var diceDef = ScriptableObject.CreateInstance<DiceDefinition>();
        diceDef.faces = new System.Collections.Generic.List<DiceFace>();

        for (int i = 1; i <= numberOfFaces; i++)
        {
            var face = ScriptableObject.CreateInstance<DiceFace>();
            face.label = $"{baseName} {i}";
            face.value = i;
            face.color = color;
            face.icon = icon;

            string facePath = $"{folderPath}/{face.label}.asset";
            AssetDatabase.CreateAsset(face, facePath);
            diceDef.faces.Add(face);
        }

        string defPath = $"{folderPath}/{diceDefName}.asset";
        AssetDatabase.CreateAsset(diceDef, defPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = diceDef;

        Debug.Log($"Created {numberOfFaces} faces and definition at {folderPath}");
    }
}
