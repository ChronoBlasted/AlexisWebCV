using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpPanel : Panel
{
    public ChronoTweenSequence ProSeq, JamSeq, SchoolSeq;

    [SerializeField] NavBar _navBar;

    [SerializeField] List<ExpLayout> _expLayoutInDecks;

    [SerializeField] ExpProScroll _expProScroll;
    [SerializeField] ExpJamsScroll _expJamsScroll;
    [SerializeField] ExpSchoolScroll _expSchoolScroll;


    public override void Init()
    {
        base.Init();

        InitLayouts();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        _navBar.Init();

        ProSeq.Init();
    }

    void InitLayouts()
    {
        foreach (var layout in _expLayoutInDecks)
        {
            layout.Init(true);
        }

        _expProScroll.Init();
        _expJamsScroll.Init();
        _expSchoolScroll.Init();
    }



}
