using UnityEditor;
using UnityEngine;

public class ReplaceWindow : EditorWindow
{
    public GameObject Template;

    [MenuItem("MyTools/Replace")]
    public static void ShowWindow()
    {
        GetWindow<ReplaceWindow>("Replace Window");
    }

    private void OnGUI()
    {
        Template = (GameObject) EditorGUILayout.ObjectField("Template", Template, typeof(GameObject), false);

        GUI.enabled = false;
        if (Template)
            if (GUILayout.Button("Replace Selected"))
                foreach (var obj in Selection.gameObjects)
                {
                    // https://docs.unity3d.com/ScriptReference/PrefabUtility.InstantiatePrefab.html
                    var prefab = (GameObject) PrefabUtility.InstantiatePrefab(Template);
                    var objXform = obj.transform;
                    var name = objXform.name;
                    var parent = objXform.parent;

                    prefab.transform.position = objXform.position;
                    DestroyImmediate(obj);
                    prefab.transform.name = name;
                    if (parent)
                        prefab.transform.parent = parent;
                }
    }
}