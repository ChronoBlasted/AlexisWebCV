using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "NewQuestData", menuName = "ScriptableObjects/NewQuestDataObject", order = 0)]
public class QuestData : ScriptableObject
{
    public LocalizedString QuestName;
    public int Amount;
    public int MaxAmount;
    public ResourceType QuestType;
}
