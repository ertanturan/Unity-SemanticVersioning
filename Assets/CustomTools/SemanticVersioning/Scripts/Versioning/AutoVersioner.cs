using System;
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

        SetVersionText();
        _versionText = GetComponent<Text>();
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
        _versionText.text = _versionData.Major + "." + _versionData.Minor + "."
                            + _versionData.Patch + "." + _versionData.Build
                            + preRelease;
        SetScriptableObjectDirty();
    }

    public void SetScriptableObjectDirty()
    {
        EditorUtility.SetDirty(_versionData);
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