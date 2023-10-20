using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private RectTransform _rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _rectTransform.anchoredPosition;
        }
         
    }

}
