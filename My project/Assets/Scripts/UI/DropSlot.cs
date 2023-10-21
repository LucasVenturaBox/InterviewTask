using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour
{
    private ItemSO _itemData;
    private Button _button;
    private string _tag;
    private bool _isFree = true;

    public bool GetIsFree { get { return _isFree; } }

    public ItemSO GetSetItemData {  get { return _itemData; } set { _itemData = value; } }

    // Start is called before the first frame update
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(UpdateCurrentItem);
    }

    public void UpdateSlot(ItemSO itemData, string tag)
    {
       _itemData = itemData;
        _tag = tag;
       _button.image.sprite = _itemData.GetSprite;
       _isFree = false;
       

    }

    public void ClearSlot()
    {
        _button.image.sprite = null;
        _itemData = null;
        _tag = string.Empty;

        _isFree = true;
        ClearCurrentItem();

    }

    private void UpdateCurrentItem()
    { 
            UIManager.instance.GetCurrentItem.GetComponent<CurrentItem>().UpdateCurrentItem(_itemData, _tag, gameObject);
    }

    private void ClearCurrentItem()
    {
        UIManager.instance.GetCurrentItem.GetComponent<CurrentItem>().ClearCurrentItem();

    }



}
