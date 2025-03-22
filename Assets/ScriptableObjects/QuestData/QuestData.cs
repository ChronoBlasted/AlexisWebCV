using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewQuestData", menuName = "ScriptableObjects/NewQuestDataObject", order = 0)]
public class QuestData : ScriptableObject
{
    public Image QuestIco;
    public LocalizedString QuestName;
    public int Amount;
    public int MaxAmount;
    public Sprite RewardSprite;
}
