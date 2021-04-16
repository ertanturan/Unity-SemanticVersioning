using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AutoVersioner))]
public class AutoVersionerEditor : Editor
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
        
        AutoVersioner autoVersioner = (AutoVersioner) target;

       

        EditorGUILayout.Space();
        autoVersioner.GetVersioner();

        EditorGUILayout.LabelField(string.Format("Major Version Info : {0}", autoVersioner.VersionData.Major));
        if (GUILayout.Button("Set for Major Update"))
        {
            autoVersioner.SetMajorUpdate();
            autoVersioner.SetVersionText();
        }

        EditorGUILayout.LabelField(string.Format("Minor Version Info : {0}", autoVersioner.VersionData.Minor));
        if (GUILayout.Button("Set for Minor Update"))
        {
            autoVersioner.SetMinorUpdate();
            autoVersioner.SetVersionText();
        }

        EditorGUILayout.LabelField(string.Format("Patch Version Info : {0}", autoVersioner.VersionData.Patch));
        if (GUILayout.Button("Set for Patch Update"))
        {
            autoVersioner.SetPatchUpdate();
            autoVersioner.SetVersionText();
        }

        EditorGUILayout.LabelField(string.Format("Pre-release Version Info : {0}", autoVersioner.VersionData.Prerelease));
        if (GUILayout.Button("Set for Pre-release Update"))
        {
            autoVersioner.SetPrerelease();
            autoVersioner.SetVersionText();
        }

        EditorGUILayout.LabelField(string.Format("Build Version Info : {0}", autoVersioner.VersionData.Build));
        if (GUILayout.Button("Set for Build Update"))
        {
            autoVersioner.SetBuild();
            autoVersioner.SetVersionText();
        }

        autoVersioner.SetVersionText();
    }
    
    private void OnValidate()
    {
        SetVersion();
    }

    private void SetVersion()
    {
        AutoVersioner autoVersioner = (AutoVersioner) target;

        autoVersioner.GetVersioner();
        autoVersioner.SetVersionText();
    }
    
}