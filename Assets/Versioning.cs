using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Versioning : MonoBehaviour
{
    [SerializeField] private Text _versionText;

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
        _versionText.text = _versionData.Major + "." + _versionData.Minor + "."
                            + _versionData.Patch + "." +
                            _versionData.Prerelease + ".+" + _versionData.Build;
    }

}