using CustomTools.SemanticVersioning.Scripts.Enum;

namespace CustomTools.SemanticVersioning.Scripts.Structures
{
    [System.Serializable]
    public struct VersionData
    {
        public int Major;
        public int Minor;
        public int Patch;
        public ReleaseType PreRelease;
        public int Build;

        public VersionData(int major, int minor, int patch, ReleaseType preRelease, int build)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
            PreRelease = preRelease;
            Build = build;
        }
    
    }
}