using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentItem : MonoBehaviour
{
    private ItemSO _itemData;
    private string _tag;
    private GameObject _currentSlot;
    private TextMeshProUGUI _name;
    private Image _image;
    private TextMeshProUGUI _stat;
    private TextMeshProUGUI _price;
    // Start is called before the first frame update

    public ItemSO GetItemData {  get { return _itemData; } }
    public string GetTag { get { return _tag; } }
    public GameObject GetCurrentSlot { get { return _currentSlot; } }

    private void Awake()
    {
        _name = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _image = transform.GetChild(1).GetComponent<Image>();
        _stat = transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        _price = transform.GetChild(5).GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCurrentItem(ItemSO itemData, string tag, GameObject currentSlot)
    {
        if (itemData != null && tag != null && currentSlot != null)
        {


            _itemData = itemData;
            _tag = tag;
            _currentSlot = currentSlot;
            //_currentItem = _shopUI.transform.GetChild(0).gameObject;
            gameObject.SetActive(true);
            gameObject.tag = _tag;
            _name.text = _itemData.GetName;
            _image.sprite = _itemData.GetSprite;
            _stat.text = _itemData.GetStat.ToString();
            _price.text = _itemData.GetPrice.ToString();
        }
    }

    public void ClearCurrentItem()
    {
        _itemData = null;
        _tag = null;
        _currentSlot = null;
    }
}
