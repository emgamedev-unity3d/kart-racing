// 5/16/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using Unity.Splines.Examples;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;

[CustomEditor(typeof(SplineContainer))]
public class SplineCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector GUI for the Spline component
        DrawDefaultInspector();

        // Add a button to the custom editor
        if (GUILayout.Button("Create Prefab with LoftRoadBehaviour and SplineInstantiate"))
        {
            CreatePrefabWithComponents();
        }
    }

    private void CreatePrefabWithComponents()
    {
        // Get the target SplineContainer
        SplineContainer splineContainer = (SplineContainer)target;

        // Ensure the GameObject has a LoftRoadBehaviour component
        LoftRoadBehaviour loftRoadBehaviour = splineContainer.gameObject.GetComponent<LoftRoadBehaviour>();
        if (loftRoadBehaviour == null)
        {
            loftRoadBehaviour = splineContainer.gameObject.AddComponent<LoftRoadBehaviour>();
            loftRoadBehaviour.Container = splineContainer; // Link the SplineContainer
            loftRoadBehaviour.m_SegmentsPerMeter = 4; // Default value
            loftRoadBehaviour.m_TextureScale = 250; // Default texture scale
        }

        // Ensure the GameObject has a SplineInstantiate component
        SplineInstantiate splineInstantiate = splineContainer.gameObject.GetComponent<SplineInstantiate>();
        if (splineInstantiate == null)
        {
            splineInstantiate = splineContainer.gameObject.AddComponent<SplineInstantiate>();
            splineInstantiate.m_Container = splineContainer; // Link the SplineContainer
            splineInstantiate.m_Method = SplineInstantiate.Method.InstanceCount; // Default method
            splineInstantiate.m_Spacing = new Vector2(10f, 10f); // Default spacing
        }

        // Prompt the user to save the prefab
        string path = EditorUtility.SaveFilePanelInProject(
            "Save Prefab",
            splineContainer.gameObject.name + "_Prefab",
            "prefab",
            "Choose a location to save the prefab."
        );

        if (!string.IsNullOrEmpty(path))
        {
            // Create the prefab at the specified path
            PrefabUtility.SaveAsPrefabAsset(splineContainer.gameObject, path);
            Debug.Log($"Prefab created at: {path}");
        }
        else
        {
            Debug.LogWarning("Prefab creation canceled.");
        }
    }
}
