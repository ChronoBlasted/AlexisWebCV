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
    [SerializeField] List<ExpData> _allExp = new List<ExpData>();
    [SerializeField] TimelineLayout _timelineLayoutPrefab;

    [SerializeField] Transform _contentLayout;


    List<TimelineLayout> _instantiatedTimelines = new List<TimelineLayout>();

    public override void Init()
    {
        base.Init();

        InitLayouts();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.ResetScroll(_scrollRect);
    }

    void InitLayouts()
    {
        foreach (var exp in _allExp)
        {
            var currentLayout = Instantiate(_timelineLayoutPrefab, _contentLayout);
            currentLayout.Init(exp);
            _instantiatedTimelines.Add(currentLayout);
        }

        SortTimelines();
    }

    private void SortTimelines()
    {
        _instantiatedTimelines = _instantiatedTimelines
            .OrderByDescending(t => DateTime.Parse(t.Data.EndTime))
            .ToList();

        for (int i = 0; i < _instantiatedTimelines.Count; i++)
        {
            _instantiatedTimelines[i].transform.SetSiblingIndex(i);
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Load All Data")]
    public void LoadAllResourcesInEditor()
    {
        _allExp = AssetDatabase.FindAssets("t:ExpData")
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(AssetDatabase.LoadAssetAtPath<ExpData>)
            .ToList();

        EditorUtility.SetDirty(this);
    }
#endif
}
