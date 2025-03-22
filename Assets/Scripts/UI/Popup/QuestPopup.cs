using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class QuestPopup : Popup
{
    [SerializeField] List<QuestData> _allQuestData;
    [SerializeField] List<QuestLayout> _questLayouts;

    public override void Init()
    {
        base.Init();

        InitQuestLayout();
    }

    void InitQuestLayout()
    {
        for (int i = 0; i < _questLayouts.Count; i++)
        {
            _questLayouts[i].Init(_allQuestData[i]);
        }
    }
}
