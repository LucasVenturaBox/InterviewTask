using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour//, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Item _item;
    private ItemSO _itemData;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Vector2 _initialPosition;
    private bool _onPointedDown = false;

    public bool GetOnPointedDown { get { return _onPointedDown; } }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _item = GetComponent<Item>();
        _itemData = _item.itemData;
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    _initialPosition = _rectTransform.anchoredPosition;
    //    UIManager.instance.CurrentItem(_itemData.GetName, _itemData.GetSprite, _itemData.GetStat.ToString(), _itemData.GetPrice.ToString());
    //}

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    _canvasGroup.blocksRaycasts = false;
    //    _canvasGroup.alpha = 0.6f;
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    _rectTransform.anchoredPosition += eventData.delta / UIManager.instance.GetCanvasScaleFactor;
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    _canvasGroup.blocksRaycasts = true;
    //    _canvasGroup.alpha = 1f;
        
    //}

    
}
