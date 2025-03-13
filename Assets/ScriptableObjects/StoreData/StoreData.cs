using UnityEngine;

[CreateAssetMenu(fileName = "NewStoreData", menuName = "ScriptableObjects/NewStoreDataObject", order = 1)]
public class StoreData : ResourceData
{
    public int Price;
    public Currency Currency;
}
