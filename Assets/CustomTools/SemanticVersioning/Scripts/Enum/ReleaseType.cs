[System.Serializable]
public enum ReleaseType
{
 
    f, // for official releases . Recommended for most cases.
    nightly, // for releases which built at night.
    hotfix, // for releases which had a major/minor bug to fix asap.
    alpha, // For testing out  major capabilities withing the company.
    beta, // for testing out major/minor capabilities within the techincal team.
    closedtest, // for testing the product within a specific group
    developmentonly,// for testing the product, major/minor capabilities
                    // or bugfixes within the software engineering team only 
    other // not specified above.
}