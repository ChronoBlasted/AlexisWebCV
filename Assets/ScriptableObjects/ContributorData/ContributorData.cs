using UnityEngine;

[CreateAssetMenu(fileName = "NewContributorData", menuName = "ScriptableObjects/NewContributorDataObject", order = 0)]
public class ContributorData : ScriptableObject
{
    public string Name;
    public string LinkedinURL;
    public Role Role;
}

public enum Role
{
    None,
    Dev,
    Artist,
    Market,
}