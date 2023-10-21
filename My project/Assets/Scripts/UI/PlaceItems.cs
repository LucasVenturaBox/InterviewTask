using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItems : MonoBehaviour
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private List<ItemSO> _items;
    private int _length = 0;

   

    public void PopulateSlots(GameObject[] slots)
    {
        LongerArray(slots);
            for (int i = 0; i < _length; i++)
            {
                slots[i].GetComponent<DropSlot>().UpdateSlot(_items[i], "Shop");
            }
         
    }

    private void LongerArray(GameObject[] slots)
    {
        if(slots.Length > _items.Count)
        {
            _length = _items.Count;
        }
        else
        {
            _length = slots.Length;
        }
    }
}
