using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;
    private InputAction[] _inputActions;

    #region Unity Methods
    private void OnEnable()
    {
        GetComponent<PlayerInput>().actions.Enable();
    }

    private void Awake()
    {
        _inputActions = GetComponent<PlayerInput>().actions.actionMaps[0].actions.ToArray();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void OnDisable()
    {
        GetComponent<PlayerInput>().actions.Disable();
    }
    #endregion

    private void Movement()
    {
        Vector2 direction = _inputActions[0].ReadValue<Vector2>();

        transform.position += new Vector3 (direction.x, direction.y, 0) * _movementSpeed;
    }

    private void Interact()
    {

    }
}
