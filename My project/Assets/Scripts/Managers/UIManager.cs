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





    public float GetCanvasScaleFactor { get { return _canvas.scaleFactor; } }
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
            _canvas = FindObjectOfType<Canvas>();
            Transform playerParentUI = _canvas.transform.GetChild(2);
            _currentItem = _canvas.transform.GetChild(0).gameObject;
            _playerBag = playerParentUI.GetChild(0).gameObject;
            _playerHUD = playerParentUI.GetChild(1).gameObject;
            _playerProfile = playerParentUI.GetChild(2).gameObject;
            _shopKeeperUI = _canvas.transform.GetChild(1).gameObject;
        }
    }

    private void Start()
    {
        _player = GameManager.instance.GetPlayer;
        _playerBag.SetActive(false);
        _playerProfile.SetActive(false);
        _shopKeeperUI.SetActive(false);
        _currentItem.SetActive(false);
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
        
    }

    public void OpenProfile()
    {
        _player.GetComponent<PlayerController>().ChangeActionMaps(false);
        _playerBag.SetActive(true);
        _playerProfile.SetActive(true);
    }

    public void CurrentItem(string name, Sprite image, string stat, string price)
    {
        //_currentItem = _shopUI.transform.GetChild(0).gameObject;
        _currentItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = name;
        _currentItem.transform.GetChild(1).GetComponent<Image>().sprite = image;
        _currentItem.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = stat;
        _currentItem.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = price;
    }

    public void Buy()
    {

    }

    public void CloseShop()
    {
        _player.GetComponent<PlayerController>().ChangeActionMaps(true);
        _playerBag.SetActive(true);
        _playerProfile.SetActive(true);
    }
    
}
