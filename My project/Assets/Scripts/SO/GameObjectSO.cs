using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIManagerReferences", menuName = "Data/UIManagerReferences", order = 1)]
public class GameObjectSO : ScriptableObject
{
    [Header("Player")]
    [SerializeField] private GameObject[] _playerUI;

    [Header("ShopKeeper")]
    [SerializeField] private GameObject[] _shopKeeperUI;

    [Header("Other")]
    [SerializeField] private GameObject[] _otherUI;

    public GameObject[] GetPlayerUI { get { return _playerUI; } }
    public GameObject[] GetShopKeeperUI { get { return _shopKeeperUI; } }
    public GameObject[] GetOtherUI { get { return _otherUI; } }
}
