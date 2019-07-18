using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

//[CustomEditor(typeof(ItemSpawner))]
[CanEditMultipleObjects]
public class ItemSpawnerEditor : Editor {

    public int index = 0;
    public string[] options = new string[] {"CD", "Blik", "Papier"};

    //SerializedProperty itemVariations;

    //void OnEnable() {
    //    itemVariations = serializedObject.FindProperty("ItemVariations");
    //}

    public override void OnInspectorGUI() {
        index = EditorGUILayout.Popup("fuck", index, options);
        if (GUILayout.Button("Spawn")) {
            SpawnItem();
        }

        //serializedObject.Update();
        //EditorGUILayout.PropertyField(itemVariations);
        //serializedObject.ApplyModifiedProperties();
    }

    void SpawnItem() {
        switch (index) {
            case 0:
                Debug.Log("Spawn CD");
                break;
            case 1:
                Debug.Log("Spawn Blik");
                break;
            case 2:
                Debug.Log("Spawn Papier");
                break;
            case 3:
                Debug.Log("Spawn Banaan");
                break;
            case 4:
                Debug.Log("Spawn Cigaret");
                break;
            case 5:
                Debug.Log("Spawn Glas");
                break;
            case 6:
                Debug.Log("Spawn Veer");
                break;
            default:
                Debug.LogError("Can't recognize the selected object", this);
                break;

        }
    }

    //public string[] options = new string[] { "Cube", "Sphere", "Plane" };
    //public int index = 0;
    //[MenuItem("Examples/Editor GUILayout Popup usage")]
    ////Editor editor = Edit

    ////static void Init() {
    ////    EditorWindow window = GetWindow(typeof(ItemSpawnerEditor));
    ////    window.Show();
    ////}

    //private void OnGUI() {
    //    index = EditorGUILayout.Popup(index, options);
    //    if (GUILayout.Button("Create")) {
    //        InstantiatePrimitive();
    //    }
    //}

    //private void InstantiatePrimitive() {
    //    switch (index) {
    //        case 0:
    //            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //            cube.transform.position = Vector3.zero;
    //            break;
    //        default:
    //            Debug.LogError("Unrecognized option");
    //            break;
    //    }
    //}
}
