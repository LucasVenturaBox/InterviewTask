using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject _player;
    private int _playerCoins;

    public int GetPlayerCoins { get { return _playerCoins; } }
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

        
    }

    public void IncrementRandomCoins(int lowestAmount, int highestAmount)
    {
        _playerCoins += Random.Range(lowestAmount, highestAmount);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
