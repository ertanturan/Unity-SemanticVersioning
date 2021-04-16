using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Versioning))]
public class VersioningEditor : Editor
{
    private void OnPreSceneGUI()
    {
        SetVersion();
    }

    private void OnSceneDrag(SceneView sceneView, int index)
    {
        SetVersion();
    }


    private void OnSceneGUI()
    {
        SetVersion();
    }

    public override void OnInspectorGUI()
    {
        
        base.OnInspectorGUI();
        
        Versioning versioning = (Versioning) target;

        EditorGUILayout.Space();
        versioning.GetVersioner();

        EditorGUILayout.LabelField(string.Format("Major Version Info : {0}", versioning.VersionData.Major));
        if (GUILayout.Button("Set for Major Update"))
        {
            versioning.SetMajorUpdate();
            versioning.SetVersionText();
        }

        EditorGUILayout.LabelField(string.Format("Minor Version Info : {0}", versioning.VersionData.Minor));
        if (GUILayout.Button("Set for Minor Update"))
        {
            versioning.SetMinorUpdate();
            versioning.SetVersionText();
        }

        EditorGUILayout.LabelField(string.Format("Patch Version Info : {0}", versioning.VersionData.Patch));
        if (GUILayout.Button("Set for Patch Update"))
        {
            versioning.SetPatchUpdate();
            versioning.SetVersionText();
        }

        EditorGUILayout.LabelField(string.Format("Pre-release Version Info : {0}", versioning.VersionData.Prerelease));
        if (GUILayout.Button("Set for Pre-release Update"))
        {
            versioning.SetPrerelease();
            versioning.SetVersionText();
        }

        EditorGUILayout.LabelField(string.Format("Build Version Info : {0}", versioning.VersionData.Build));
        if (GUILayout.Button("Set for Build Update"))
        {
            versioning.SetBuild();
            versioning.SetVersionText();
        }

        versioning.SetVersionText();
    }
    
    private void OnValidate()
    {
        SetVersion();
    }

    private void SetVersion()
    {
        Versioning versioning = (Versioning) target;

        versioning.GetVersioner();
        versioning.SetVersionText();
    }
    
}