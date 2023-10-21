using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSlots : MonoBehaviour
{
    private Vector2 _borderSize = new Vector2(20,20);
    [SerializeField] private GameObject _slot;
    private RectTransform _slotRectTransform;
    private RectTransform _rectTransform;
    private Vector2 _inventorySize;
    private Vector2 _slotSize;
    private int _xSlots;
    private int _ySlots;
    private List<GameObject> _slots = new List<GameObject>();
    private List<GameObject> _freeSlots = new List<GameObject>();
    private PlaceItems _placeItems;
    
    
    public List<GameObject> GetFreeSlots { get { return _freeSlots; } }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _slotRectTransform = _slot.GetComponent<RectTransform>();
        
    }

    private void Start()
    {
        CreateInventorySlots();
        if (GetComponent<PlaceItems>() != null)
        {
            _placeItems = GetComponent<PlaceItems>();
            _placeItems.PopulateSlots(_slots.ToArray());

        }

    }

    public void CreateInventorySlots()
    {
        _inventorySize = new Vector2(_rectTransform.rect.width, _rectTransform.rect.height);

        _slotSize = new Vector2(_slotRectTransform.rect.width, _slotRectTransform.rect.height);
        


        float slotAndBorderAlongX = _slotSize.x + _borderSize.x;
        float inventoryWidth = _inventorySize.x - _borderSize.x;
        float slotsByWidth = inventoryWidth / slotAndBorderAlongX;

        if(Mathf.Abs((int)slotsByWidth - slotsByWidth) > 0)
        {
            _xSlots = Mathf.FloorToInt(slotsByWidth);
            
        }

        if (_xSlots < 0)
        {
            Debug.LogError(" The inventory is not wide enough, or either the slots or borders are too wide");
            return;
        }


        float slotAndBorderAlongY = _slotSize.y + _borderSize.y;
        float inventoryHeight = _inventorySize.y - _borderSize.y;
        float slotsByHeight = inventoryHeight / slotAndBorderAlongY;

        if (Mathf.Abs((int)slotsByHeight - slotsByHeight) > 0)
        {
            _ySlots = Mathf.FloorToInt(slotsByHeight);

        }

        if (_ySlots < 0)
        {
            Debug.LogError(" The inventory is not Tall enough, or either the slots or borders are too Tall");
            return;
        }
        
        float inventoryRatio = _inventorySize.x/_inventorySize.y;

        for (int y = _ySlots; y > 0; y--)
        {
            for (int x = 0; x < _xSlots; x++)
            {
                GameObject newSlot = Instantiate(_slot, _rectTransform);
                newSlot.GetComponent<RectTransform>().localPosition = new Vector2(x * slotAndBorderAlongX + slotAndBorderAlongX - _inventorySize.y * inventoryRatio ,y * slotAndBorderAlongY - _borderSize.y - _inventorySize.y );
                _slots.Add(newSlot);
                
            }
        }

    }

    public List<GameObject> CheckFreeSlots()
    {
        _freeSlots.Clear();
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].GetComponent<DropSlot>().GetIsFree)
            {
                _freeSlots.Add(_slots[i]);
            }
        }
        return _freeSlots;
    }
}
