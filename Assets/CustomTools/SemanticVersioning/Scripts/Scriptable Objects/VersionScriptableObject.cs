using System;
using System.Collections;
using System.Collections.Generic;
using CustomTools.SemanticVersioning.Scripts.Enum;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


public class VersionScriptableObject : ScriptableObject
{
    #region Fields And Properties

    [SerializeField] private VersionData _versionData;

    public int Major
    {
        get => _versionData.Major;
        set => _versionData.Major = value;
    }



    public int Minor
    {
        get => _versionData.Minor;
        set => _versionData.Minor = value;

    }


    public int Patch
    {
        get => _versionData.Patch;
        set => _versionData.Patch = value;
    }


    public ReleaseType Prerelease
    {
        get => _versionData.PreRelease;
        set => _versionData.PreRelease = value;
    }


    public int Build
    {
        get => _versionData.Build;
        set => _versionData.Build = value;
    }

    #endregion

    #region Custom Methods

    public void SetMajorUpdate()
    {
        _versionData.Major++;
        _versionData.Minor = 0;
        _versionData.Build = 0;
        _versionData.Patch = 0;
        
    }

    public void SetMinorUpdate()
    {
        _versionData.Minor++;
        _versionData.Build = 0;
        _versionData.Patch = 0;
    }

    public void SetPatchUpdate()
    {
        _versionData.Patch++;
        _versionData.Build = 0;
    }

    public void SetPrerelease(ReleaseType type)
    {
        _versionData.PreRelease = type;
    }

    public void SetBuild()
    {
        _versionData.Build++;
    }


    public void ResetScriptableObject()
    {
        _versionData.Major = 0;
        _versionData.Minor = 0;
        _versionData.Build = 0;
        _versionData.Patch = 0;
        _versionData.PreRelease = ReleaseType.None;
    }

    #endregion
}