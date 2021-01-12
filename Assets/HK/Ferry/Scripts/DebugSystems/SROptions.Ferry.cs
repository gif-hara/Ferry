using System.ComponentModel;
using HK.Ferry.Extensions;
using HK.Ferry.UserSystems;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// 
/// </summary>
public partial class SROptions
{
    [Category("アイテム付与")]
    [DisplayName("ItemId")]
    [Sort(1000)]
    public int ItemId
    {
        get;
        set;
    }

    [Category("アイテム付与")]
    [DisplayName("ItemNumber")]
    [Sort(1001)]
    public int ItemNumber
    {
        get;
        set;
    }

    [Category("アイテム付与")]
    [DisplayName("実行")]
    [Sort(1002)]
    public void AddItem()
    {
        UserData.Instance.Item.Add(ItemId, ItemNumber);
        UserData.Instance.Save();
    }
}
