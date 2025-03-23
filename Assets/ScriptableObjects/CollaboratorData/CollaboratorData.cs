using UnityEngine;

[CreateAssetMenu(fileName = "NewCollaboratorData", menuName = "ScriptableObjects/NewCollaboratorDataObject", order = 0)]
public class CollaboratorData : ScriptableObject
{
    public string FirstName;
    public string LastName;
    public Role Role;
}

