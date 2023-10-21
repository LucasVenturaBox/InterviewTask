using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        Debug.Log("it says it is null");
        if (UIManager.instance.GetCurrentItem != null)
        {
            Debug.Log("Something is happening on the BuyItem method");
            CurrentItem currentItem = UIManager.instance.GetCurrentItem.GetComponent<CurrentItem>();
            ItemSO itemData = currentItem.GetItemData;
            GameObject currentSlot = currentItem.GetCurrentSlot;
            string tag = currentItem.GetTag;
            if (tag == "Shop")
            {
                if (GameManager.instance.GetPlayerCoins >= itemData.GetPrice)
                {
                    if (UIManager.instance.GetPlayerBag.transform.GetChild(0).GetComponent<CreateSlots>().CheckFreeSlots().Count > 0)
                    {
                        currentSlot.GetComponent<DropSlot>().ClearSlot();
                        GameManager.instance.DecrementCoins(itemData.GetPrice);
                        GameObject newItemSlot = UIManager.instance.GetPlayerBag.transform.GetChild(0).GetComponent<CreateSlots>().CheckFreeSlots()[0];
                        newItemSlot.GetComponent<DropSlot>().UpdateSlot(itemData, "Bag");
                    }
                    else
                    {
                        Debug.LogWarning("You don't have any slots available on your inventory");
                    }
                }
                else
                {
                    Debug.LogWarning("You don't have enough coins");
                }
            }
            else
            {
                Debug.LogWarning("Can only buy items from the shop");
            }
        }
       
    }
}
