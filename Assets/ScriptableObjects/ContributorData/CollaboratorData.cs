using UnityEngine;

[CreateAssetMenu(fileName = "NewCollaboratorData", menuName = "ScriptableObjects/NewCollaboratorDataObject", order = 0)]
public class CollaboratorData : ScriptableObject
{
    public string Name;
    public string LinkedinURL;
    public Role Role;
}

