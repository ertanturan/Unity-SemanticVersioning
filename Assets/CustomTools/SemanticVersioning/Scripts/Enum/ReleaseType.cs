namespace CustomTools.SemanticVersioning.Scripts.Enum
{
    [System.Serializable]
    public enum ReleaseType
    {
 
        None,// use when no tag/type needed
        F, // for official releases . Recommended for most cases.
        Nightly, // for releases which built at night.
        Hotfix, // for releases which had a major/minor bug to fix asap.
        Alpha, // For testing out  major capabilities withing the company.
        Beta, // for testing out major/minor capabilities within the techincal team.
        Closedtest, // for testing the product within a specific group
        Developmentonly,// for testing the product, major/minor capabilities
        // or bugfixes within the software engineering team only 
        Other // not specified above.
    }
}