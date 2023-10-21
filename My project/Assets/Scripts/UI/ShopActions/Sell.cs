using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(SellItem);
    }

    private void SellItem()
    {
       
        if (UIManager.instance.GetCurrentItem != null)
        {
            CurrentItem currentItem = UIManager.instance.GetCurrentItem.GetComponent<CurrentItem>();
            ItemSO itemData = currentItem.GetItemData;
            GameObject currentSlot = currentItem.GetCurrentSlot;
            string tag = currentItem.GetTag;
            if (tag == "Bag")
            {
                        currentSlot.GetComponent<DropSlot>().ClearSlot();
                        GameManager.instance.IncrementCoins(itemData.GetPrice);   
            }
            else
            {
                Debug.LogWarning("Can only sell items from the bag");
            }
        }

    }
}
