using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject _player;

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
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
