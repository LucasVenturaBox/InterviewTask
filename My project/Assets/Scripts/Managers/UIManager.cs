using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
    private GameObject _currentItem;
    public static UIManager instance;
    private Canvas _canvas;
    private GameObject _player;
    private GameObject _playerBag;
    private GameObject _playerProfile;
    private GameObject _playerHUD;
    private GameObject _shopKeeperUI;
    private GameObject _buyScreen;

    public float GetCanvasScaleFactor { get { return _canvas.scaleFactor; } }

    public GameObject GetPlayerProfile { get { return _playerProfile; } }
    public GameObject GetPlayerBag { get { return _playerBag; } }
    public GameObject GetShopKeeperUI { get { return _shopKeeperUI; } }

    public GameObject GetCurrentItem { get { return _currentItem; } }

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

        if (SceneManager.GetActiveScene().name == "Test")
        {
            _player = GameManager.instance.GetPlayer;
            _canvas = FindObjectOfType<Canvas>();
            Transform playerParentUI = _canvas.transform.GetChild(0);
            _playerProfile = playerParentUI.GetChild(0).gameObject;
            _playerBag = playerParentUI.GetChild(1).gameObject;
            _playerHUD = playerParentUI.GetChild(2).gameObject;
            _shopKeeperUI = _canvas.transform.GetChild(1).gameObject;
            _currentItem = _canvas.transform.GetChild(2).gameObject;
            _buyScreen = _canvas.transform.GetChild(3).gameObject;

        }
    }

    private void Start()
    {
        
        _playerBag.SetActive(false);
        _playerProfile.SetActive(false);
        _shopKeeperUI.SetActive(false);
        _currentItem.SetActive(false);
        _buyScreen.SetActive(false);
    }

    public void UpdateCoinDisplay()
    {
        GameObject coinDisplay = _playerHUD.transform.GetChild(1).gameObject;
        coinDisplay.GetComponent<TextMeshProUGUI>().text = GameManager.instance.GetPlayerCoins.ToString();
    }

    public void OpenShop()
    {
        _player.GetComponent<PlayerController>().ChangeActionMaps(false);
        _playerBag.SetActive(true);
        _playerProfile.SetActive(true);
        _shopKeeperUI.SetActive(true);
        _buyScreen.SetActive(true);
        
    }

    public void OpenProfile()
    {
        _player.GetComponent<PlayerController>().ChangeActionMaps(false);
        _playerBag.SetActive(true);
        _playerProfile.SetActive(true);
    }

 

    public void CloseUI()
    {
        _player.GetComponent<PlayerController>().ChangeActionMaps(true);
        _playerBag.SetActive(false);
        _playerProfile.SetActive(false);
        _shopKeeperUI.SetActive(false);
        _currentItem.SetActive(false);
        _buyScreen.SetActive(false);
    }
    
}
