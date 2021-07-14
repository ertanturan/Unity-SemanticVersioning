using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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

        autoVersioner.SetVersionTextComponent();

        EditorGUILayout.Space();
        autoVersioner.GetVersioner();

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField($"Major Version Info : {autoVersioner.VersionData.Major}");
        if (GUILayout.Button("+",GUILayout.Width(25),GUILayout.Height(25)))
        {
            autoVersioner.SetMajorUpdate();
        }
        EditorGUILayout.EndHorizontal();

        
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField($"Minor Version Info : {autoVersioner.VersionData.Minor}");
        if (GUILayout.Button("+",GUILayout.Width(25),GUILayout.Height(25)))
        {
            autoVersioner.SetMinorUpdate();
        }
        EditorGUILayout.EndHorizontal();

        
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField($"Patch Version Info : {autoVersioner.VersionData.Patch}");
        if (GUILayout.Button("+",GUILayout.Width(25),GUILayout.Height(25)))
        {
            autoVersioner.SetPatchUpdate();
        }

        EditorGUILayout.EndHorizontal();

        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField($"Pre-release Version Info : {autoVersioner.VersionData.Prerelease}");
        
        
            autoVersioner.SetPrerelease();
        
        
        EditorGUILayout.EndHorizontal();

        
        EditorGUILayout.BeginHorizontal();

        
        EditorGUILayout.LabelField($"Build Version Info : {autoVersioner.VersionData.Build}");
        if (GUILayout.Button("+",GUILayout.Width(25),GUILayout.Height(25)))
        {
            autoVersioner.SetBuild();
        }
        EditorGUILayout.EndHorizontal();

        autoVersioner.SetVersionText();
    
        // autoVersioner.SetScriptableObjectDirty();
        
        
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