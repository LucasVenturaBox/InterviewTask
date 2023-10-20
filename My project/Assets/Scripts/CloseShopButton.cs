using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseShopButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(UIManager.instance.CloseShop);
    }
}
