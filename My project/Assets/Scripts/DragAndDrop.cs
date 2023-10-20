using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Vector2 _initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _initialPosition = _rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / UIManager.instance.GetCanvasScaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
    }

   

    



}
