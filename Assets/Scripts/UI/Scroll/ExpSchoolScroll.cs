using System.Collections.Generic;
using UnityEngine;

public class ExpSchoolScroll : RecyclableScroll<ExpData, ExpLayout>
{
    [SerializeField] List<ExpData> _allExp;

    public void Init()
    {
        SetData(_allExp);
    }

    public void ResetScroll()
    {
        UIManager.ResetScroll(_scrollRect);
        UpdateVisibleItems();
    }
}
