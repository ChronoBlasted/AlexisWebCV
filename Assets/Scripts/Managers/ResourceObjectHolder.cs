using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using BaseTemplate.Behaviours;
using UnityEditor;

public class ResourceObjectHolder : MonoSingleton<ResourceObjectHolder>
{
    [SerializeField] List<ResourceData> _resources;

    public ResourceData GetResourceByType(ResourceType resourceType)
    {
        return _resources.First(resource => resource.Type == resourceType);
    }

#if UNITY_EDITOR
    [ContextMenu("Load All Data")]
    public void LoadAllResourcesInEditor()
    {
        _resources = AssetDatabase.FindAssets("t:ResourceData")
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(AssetDatabase.LoadAssetAtPath<ResourceData>)
            .ToList();

        EditorUtility.SetDirty(this);
    }
#endif
}
