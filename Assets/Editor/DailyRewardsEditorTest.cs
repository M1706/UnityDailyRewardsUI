#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DailyRewardsManager))]
public class DailyRewardsEditorTest : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DailyRewardsManager manager = (DailyRewardsManager)target;

        if (GUILayout.Button("Populate Rewards"))
        {
            manager.PopulateRewards(); // Simulate Start() to populate the UI
        }
    }
}
#endif