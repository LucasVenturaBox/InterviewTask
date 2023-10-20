using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerInventory;
    [SerializeField] private GameObject _shopUI;
    public static UIManager instance;
    private Canvas _canvas;
    private GameObject _player;
   

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
    }

    private void Start()
    {
        _canvas = FindObjectOfType<Canvas>();
        
        _player = GameManager.instance.GetPlayer;
        _shopUI.SetActive(false);
    }

    public void OpenShop()
    {
        _player.GetComponent<PlayerController>().ChangeActionMaps(false);
        _playerInventory.SetActive(true);
        _shopUI.SetActive(true);
    }

    public void CloseShop()
    {
        _player.GetComponent<PlayerController>().ChangeActionMaps(true);
        _playerInventory.SetActive(false);
        _shopUI.SetActive(false);
    }
    
}
