using UnityEngine;
using UnityEditor;

public static class FoldHierarchyShortcut
{
    //すべて折りたたむ
    [MenuItem("Tools/Fold Selected Hierarchy %&-")] // Ctrl + Alt + -
    private static void FoldSelected()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            SetExpandedRecursive(obj, false);
        }
    }

    //すべて展開する
    [MenuItem("Tools/Unfold Selected Hierarchy %&+")] // Ctrl + Alt + +
    private static void UnfoldSelected()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            SetExpandedRecursive(obj, true);
        }
    }

    private static void SetExpandedRecursive(GameObject go, bool expand)
    {
        var hierarchyType = typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneHierarchyWindow");
        var window = EditorWindow.GetWindow(hierarchyType);
        var method = hierarchyType.GetMethod("SetExpandedRecursive", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
        method.Invoke(window, new object[] { go.GetInstanceID(), expand });
    }
}