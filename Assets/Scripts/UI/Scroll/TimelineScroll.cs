using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class TimelineScroll : RecyclableScroll<ExpData, TimelineLayout>
{
    [SerializeField] List<ExpData> _allExp;

    public void Init()
    {
        SetData(_allExp);
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
