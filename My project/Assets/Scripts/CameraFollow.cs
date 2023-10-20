using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject _player;
    private void Start()
    {
        _player = GameManager.instance.GetPlayer;
    }
    private void Update()
    {
        transform.position = _player.transform.position + new Vector3(0,0, -10f);
    }
}
