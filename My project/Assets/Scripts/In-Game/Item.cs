using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemSO itemData;
    private Image _image;
    private Animator _animator;
    private DragAndDrop _dragAndDrop;
    private bool _locked;

    public bool SetGetLocked { get { return _locked; } set { value = _locked; } }

    private void Awake()
    {
        _dragAndDrop = GetComponent<DragAndDrop>();
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _image.sprite = itemData.GetSprite;
    }

    

    
}
