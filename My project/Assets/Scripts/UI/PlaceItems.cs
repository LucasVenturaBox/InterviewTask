using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItems : MonoBehaviour
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private ItemSO[] _items;
    private CreateSlots _createSlots;
    private int _length = 0;

    private void Awake()
    {
        _createSlots = GetComponent<CreateSlots>();
    }

    private void Start()
    {
        PopulateSlots(_createSlots.GetSlots.ToArray());
    }

    public void PopulateSlots(GameObject[] slots)
    {
        LongerArray(slots);
           
            Debug.Log(slots.Length);
            Debug.Log(_items.Length);
            for (int i = 0; i < _length; i++)
            {
           
                    GameObject newItem = Instantiate(_itemPrefab, transform);
                    newItem.GetComponent<Item>().itemData = _items[i];
                    newItem.GetComponent<RectTransform>().localPosition = slots[i].GetComponent<RectTransform>().localPosition; 
            }
         
    }

    private void LongerArray(GameObject[] slots)
    {
        if(slots.Length > _items.Length)
        {
            _length = _items.Length;
        }
        else
        {
            _length = slots.Length;
        }
    }
}
