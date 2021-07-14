﻿using System;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[ExecuteInEditMode]
public class AutoVersioner : MonoBehaviour
{
    #region Fields And Properties

    private Text _versionText;

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

    #endregion

    #region Builtin Methods

    private void Start()
    {
        GetVersioner();
        _versionData.SetBuild();

        if (_versionText == null)
        {
            _versionText = GetComponent<Text>();
        }

        SetVersionText();
    }

    #endregion

    #region Custom Methods

    public void SetMajorUpdate()
    {
        GetVersioner();

        _versionData.SetMajorUpdate();
        SetVersionText();
    }

    public void SetMinorUpdate()
    {
        GetVersioner();

        _versionData.SetMinorUpdate();
        SetVersionText();
    }

    public void SetPatchUpdate()
    {
        GetVersioner();

        _versionData.SetPatchUpdate();
        SetVersionText();
    }

    public void SetPrerelease()
    {
        GetVersioner();

        _versionData.SetPrerelease(_releaseType);
        SetVersionText();
    }

    public void SetBuild()
    {
        GetVersioner();
        _versionData.SetBuild();
        SetVersionText();
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
        StringBuilder versionSb = new StringBuilder();

        versionSb.Append(_versionData.Major);
        versionSb.Append(".");
        versionSb.Append(_versionData.Minor);
        versionSb.Append(".");
        versionSb.Append(_versionData.Patch);
        versionSb.Append(".");
        versionSb.Append(_versionData.Build);
        versionSb.Append(preRelease);

        _versionText.text = versionSb.ToString();
        SetScriptableObjectDirty();
    }

    public void SetScriptableObjectDirty()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(_versionData);
#endif
    }

#if UNITY_EDITOR
    public void SetVersionTextComponent()
    {
        _versionText = GetComponent<Text>();
    }
#endif

    public void ResetVersionData()
    {
        _versionData.ResetScriptableObject();
        SetVersionText();
    }

    #endregion
}