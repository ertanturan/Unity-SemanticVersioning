using System.Collections;
using System.Collections.Generic;
using CustomTools.SemanticVersioning.Scripts.Enum;
using UnityEngine;

[System.Serializable]
public struct VersionData
{
    public int Major;
    public int Minor;
    public int Patch;
    public ReleaseType PreRelease;
    public int Build;
}