using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData", order = 0)]
public class ItemSO : ScriptableObject
{
    [SerializeField] private string _name = "";
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private AnimationClip[] _animations;
    [SerializeField] private int  _price = 0;
    [SerializeField] private float _stat = 0;

    public string GetName{ get { return _name;} }
    public Image GetImage{ get { return _image;  } }
    public Sprite GetSprite { get { return _sprite;  } }
    public AnimationClip[] GetAnimations { get { return _animations;  } }
    public int GetPrice { get { return _price;  } }
    public float GetStat { get { return _stat;  } }

}
