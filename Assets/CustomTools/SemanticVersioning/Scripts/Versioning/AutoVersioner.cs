﻿using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class AutoVersioner : MonoBehaviour
{
    [SerializeField] private Text _versionText;

    public Text VersionText
    {
        get => _versionText;
    }

    private VersionScriptableObject _versionData;

    public VersionScriptableObject VersionData
    {
        get => _versionData;
        private set => _versionData = value;
    }


    public ReleaseType _releaseType;


    private void Start()
    {
        GetVersioner();
        _versionData.SetBuild();

        SetVersionText();
        _versionText = GetComponent<Text>();
    }

    public void SetMajorUpdate()
    {
        GetVersioner();

        _versionData.SetMajorUpdate();
    }

    public void SetMinorUpdate()
    {
        GetVersioner();

        _versionData.SetMinorUpdate();
    }

    public void SetPatchUpdate()
    {
        GetVersioner();

        _versionData.SetPatchUpdate();
    }

    public void SetPrerelease()
    {
        GetVersioner();

        _versionData.SetPrerelease(_releaseType);
    }

    public void SetBuild()
    {
        GetVersioner();
        _versionData.SetBuild();
    }

    public void GetVersioner()
    {
        _versionData = Resources.Load<VersionScriptableObject>(
            "SOC/Versioner");
    }

    public void SetVersionText()
    {
        if (VersionText == null)
        {
            Debug.LogWarning("Version text cannot be null in `AutoVersioner` class..");
            return;
        }

        string preRelease = _versionData.Prerelease == ReleaseType.None ? "" : _versionData.Prerelease.ToString();
        _versionText.text = _versionData.Major + "." + _versionData.Minor + "."
                            + _versionData.Patch + "." + _versionData.Build
                            + preRelease;

        EditorUtility.SetDirty(_versionData);
    }

#if UNITY_EDITOR
    public void SetVersionTextComponent()
    {
        _versionText = GetComponent<Text>();
    }
#endif
}