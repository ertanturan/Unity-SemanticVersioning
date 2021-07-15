using CustomTools.SemanticVersioning.Scripts.Structures;

namespace CustomTools.SemanticVersioning.Scripts.Versioning
{
    public static class VersionOperations
    {
        public static bool IsOlder(this VersionData versionData, VersionData versionDataToCompare)
        {
            return versionData.Major < versionDataToCompare.Major ||
                   versionData.Minor < versionDataToCompare.Minor ||
                   versionData.Patch < versionDataToCompare.Patch ||
                   versionData.Build < versionDataToCompare.Build;
            ;
        }
    }
}