using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadPanel : Panel
{
    public override void Init()
    {
        base.Init();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
    }

    //public void UpdateStoredBlast(List<Blast> decks)
    //{
    //    foreach (Transform child in _storedBlastTransform.transform)
    //    {
    //        Destroy(child.gameObject);
    //    }

    //    for (int i = 0; i < decks.Count; i++)
    //    {
    //        var currentBlast = Instantiate(_blastLayoutPrefab, _storedBlastTransform);

    //        currentBlast.Init(decks[i], i);
    //    }
    //}

    //public void UpdateDeckBlast(List<Blast> decks)
    //{
    //    _squadDeckLayout.UpdateDeckBlast(decks);
    //}

    //public void UpdateStoredItem(List<Item> items)
    //{
    //    foreach (Transform child in _storedItemTransform.transform)
    //    {
    //        Destroy(child.gameObject);
    //    }

    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        var currentItem = Instantiate(_itemLayoutPrefab, _storedItemTransform);

    //        currentItem.Init(items[i], i);
    //    }
    //}

    //public void UpdateDeckItem(List<Item> decks)
    //{
    //    _bagDeckLayout.UpdateDeckItems(decks);
    //}
}
