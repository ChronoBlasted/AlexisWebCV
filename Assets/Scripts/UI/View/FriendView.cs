using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class FriendView : View
{
    [SerializeField] List<CollaboratorData> contributorDatas;
    [SerializeField] List<ExpData> _allExp;

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
        var sortedContributors = contributorDatas
            .Select(data => new
            {
                Contributor = data,
                CollaborationCount = GetCollaborationAmountByCollaborator(data)
            })
            .OrderByDescending(entry => entry.CollaborationCount)
            .ToList();

        foreach (var entry in sortedContributors)
        {
            var currentContributor = Instantiate(_friendLayoutPrefab, _friendContainer);
            currentContributor.Init(entry.Contributor, entry.CollaborationCount);
        }
    }

    int GetCollaborationAmountByCollaborator(CollaboratorData collaborator)
    {
        int amount = 0;
        foreach (var exp in _allExp)
        {
            foreach (var coll in exp.Collaborators)
            {
                if (coll == collaborator) amount++;
            }
        }

        return amount;
    }

#if UNITY_EDITOR
    [ContextMenu("Load All Data")]
    public void LoadAllResourcesInEditor()
    {
        contributorDatas = AssetDatabase.FindAssets("t:CollaboratorData")
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(AssetDatabase.LoadAssetAtPath<CollaboratorData>)
            .ToList();

        _allExp = AssetDatabase.FindAssets("t:ExpData")
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(AssetDatabase.LoadAssetAtPath<ExpData>)
            .ToList();

        EditorUtility.SetDirty(this);
    }
#endif
}
