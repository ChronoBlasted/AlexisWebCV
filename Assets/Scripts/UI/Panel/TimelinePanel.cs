using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimelinePanel : Panel
{
    [SerializeField] ScrollRect _scrollRect;
    [SerializeField] TimelineScroll _timelineScroll;


    public override void Init()
    {
        base.Init();

        _timelineScroll.Init();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();


        UIManager.ResetScroll(_scrollRect);
    }
}
