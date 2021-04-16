using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

// [CreateAssetMenu(fileName = "Versioner",menuName = "CustomTools/Create New Versioner")]
public class VersionScriptableObject : ScriptableObject
{
    
    #region Fields And Properties
    [SerializeField] private int _major;

    public int Major
    {
        get => _major;
    }

    [SerializeField] private int _minor;


    public int Minor
    {
        get => _minor;
    }

    [SerializeField] private int _patch;

    public int Patch
    {
        get => _patch;
    }

    [SerializeField] private ReleaseType _prerelease;

    public ReleaseType Prerelease => _prerelease;

    [SerializeField] private int _build;

    public int Build => _build;
    

    #endregion
    
    #region Custom Methods

    public void SetMajorUpdate()
    {
        _major++;
        _minor = 0;
        _build = 0;
        _patch = 0;
    }
    
    public void SetMinorUpdate()
    {
        _minor++;
        _build = 0;
        _patch = 0;
    }
    
    public void SetPatchUpdate()
    {
        _patch++;
        _build = 0;
    }
    
    public void SetPrerelease(ReleaseType type)
    {
        _prerelease = type;
    }
    
    public void SetBuild()
    {
        _build++;
    }

    #endregion
        
}