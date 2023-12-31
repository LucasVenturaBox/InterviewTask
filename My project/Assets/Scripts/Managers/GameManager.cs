using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject _player;
    private int _playerCoins;
    private float _playerStats;



    public int GetPlayerCoins { get { return _playerCoins; } }

    public float GetPlayerStats { get { return _playerStats; } }

    public GameObject GetPlayer { get { return _player; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        _player = FindObjectOfType<PlayerController>().gameObject;        
    }

    public void IncrementRandomCoins(int lowestAmount, int highestAmount)
    {
        _playerCoins += Random.Range(lowestAmount, highestAmount);
        Debug.Log("IncrementedRandomCoins");
        UIManager.instance.UpdateCoinDisplay();
    }

    public void IncrementCoins(int amount)
    {
        _playerCoins += amount;
        UIManager.instance.UpdateCoinDisplay();
    }

    public void DecrementCoins(int amount)
    {
        _playerCoins -= amount;
        UIManager.instance.UpdateCoinDisplay();
    }

    public void CalculatePlayerStats()
    {
        //_playerStats = 0;
        //for (int i = 0; i < UIManager.instance.GetPlayerProfile.transform.GetChild(0).transform.childCount; i++)
        //{
        //    if (UIManager.instance.GetPlayerProfile.transform.GetChild(0).transform.GetChild(i).GetComponent<DropSlot>() != null)
        //    {
        //        _playerStats += UIManager.instance.GetPlayerProfile.transform.GetChild(0).transform.GetChild(i).GetComponent<DropSlot>().GetSetItemData.GetStat;
        //    }
        //}

        //UIManager.instance.UpdateStatsDisplay();
         
    }

}
