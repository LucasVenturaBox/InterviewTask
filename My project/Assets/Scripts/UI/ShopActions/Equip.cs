using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equip : MonoBehaviour
{
    private Button _button;
    private CurrentItem currentItem;
    private ItemSO itemData;
    private GameObject currentSlot;
    private Transform playerProfile;
    private string _tag;
    private DropSlot _currentDropSlot;

    private void Awake()
    {
        _button = GetComponent<Button>();

       
    }

    private void Start()
    {
        _button.onClick.AddListener(EquipItem);

        
            
            

        
    }

    private void EquipItem()
    {
        if (UIManager.instance.GetCurrentItem != null )
        {
        currentItem = UIManager.instance.GetCurrentItem.GetComponent<CurrentItem>();
        itemData = currentItem.GetItemData;
        currentSlot = currentItem.GetCurrentSlot;
        playerProfile = UIManager.instance.GetPlayerProfile.transform.GetChild(0);
        _tag = currentItem.GetTag;

            if (_tag == "Bag")
            {
                if (!playerProfile.GetChild(itemData.GetTypeOfItem).GetComponent<DropSlot>().GetIsFree) //If the desired slot is not free
                {
                    SwitchEquipment(itemData.GetTypeOfItem);
                }
                else
                {
                    SimpleEquip(itemData.GetTypeOfItem);
                }

                GameManager.instance.CalculatePlayerStats();
            } 
           
        }

    }

    public void SwitchEquipment(int childIndex)
    {
        currentSlot.GetComponent<DropSlot>().ClearSlot();
        currentSlot.GetComponent<DropSlot>().UpdateSlot(playerProfile.GetChild(childIndex).GetComponent<DropSlot>().GetSetItemData, "Bag"); //set the current slot data as the item the desired slot
        GameObject newItemSlot = playerProfile.GetChild(childIndex).gameObject;
        newItemSlot.GetComponent<DropSlot>().ClearSlot();
        newItemSlot.GetComponent<DropSlot>().UpdateSlot(itemData, "Profile"); //and the desired slot with the new data
    }

    private void SimpleEquip(int childIndex)
    {
        currentSlot.GetComponent<DropSlot>().ClearSlot();
        GameObject newItemSlot = playerProfile.GetChild(childIndex).gameObject;
        newItemSlot.GetComponent<DropSlot>().UpdateSlot(itemData, "Profile");
    }

}
