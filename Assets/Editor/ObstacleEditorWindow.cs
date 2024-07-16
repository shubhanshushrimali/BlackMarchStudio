using UnityEditor;
using UnityEngine;

public class ObstacleEditorWindow : EditorWindow
{
    private ObstacleData obstacleData;

    [MenuItem("Tools/Obstacle Editor")]
    public static void ShowWindow()
    {
        GetWindow<ObstacleEditorWindow>("Obstacle Editor");
    }

    void OnGUI()
    {
        obstacleData = EditorGUILayout.ObjectField("Obstacle Data", obstacleData, typeof(ObstacleData), false) as ObstacleData;

        if (obstacleData != null)
        {
            for (int i = 0; i < 10; i++)
            {
                EditorGUILayout.BeginHorizontal();
                for (int j = 0; j < 10; j++)
                {
                    int index = i * 10 + j;
                    obstacleData.obstacleGrid[index] = GUILayout.Toggle(obstacleData.obstacleGrid[index], "");
                }
                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("Save Obstacles"))
            {
                EditorUtility.SetDirty(obstacleData);
                AssetDatabase.SaveAssets();
            }
        }
    }
}
