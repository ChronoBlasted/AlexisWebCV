using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class FriendView : View
{
    [SerializeField] List<CollaboratorData> contributorDatas;

    [SerializeField] FriendLayout _friendLayoutPrefab;
    [SerializeField] Transform _friendContainer;

    public override void Init()
    {
        base.Init();

        InitFriendLayout();
    }

    public void Close()
    {
        UIManager.Instance.ChangeView(UIManager.Instance.MenuView);
    }
    void InitFriendLayout()
    {
        foreach (var data in contributorDatas)
        {
            var currentContributor = Instantiate(_friendLayoutPrefab, _friendContainer);
            currentContributor.Init(data);
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Load All Data")]
    public void LoadAllResourcesInEditor()
    {
        contributorDatas = AssetDatabase.FindAssets("t:CollaboratorData")
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(AssetDatabase.LoadAssetAtPath<CollaboratorData>)
            .ToList();

        EditorUtility.SetDirty(this);
    }
#endif
}
