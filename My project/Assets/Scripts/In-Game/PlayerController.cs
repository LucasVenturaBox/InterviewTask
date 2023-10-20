using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _interactionRadius = 1;
    private PlayerInput _playerInput;
    private InputAction[] _gameplayInputActions;
    private InputActionMap [] _inputActionMaps;

    #region Unity Methods
    private void OnEnable()
    {
        GetComponent<PlayerInput>().actions.Enable();
    }

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _inputActionMaps = _playerInput.actions.actionMaps.ToArray();
        _gameplayInputActions = _inputActionMaps[0].actions.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputActionMaps[0].enabled)
        {
            Movement();
            Interact();
            Profile();
        }
        else if (_inputActionMaps[1].enabled)
        {

        }
    }

    private void OnDisable()
    {
        GetComponent<PlayerInput>().actions.Disable();
    }
    #endregion

    #region Actions

    private void Movement()
    {
        Vector2 direction = _gameplayInputActions[0].ReadValue<Vector2>();

        transform.position += new Vector3 (direction.x, direction.y, 0) * _movementSpeed * Time.deltaTime;
    }

    private void Interact()
    {
        bool isInteracting = _gameplayInputActions[1].triggered;
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _interactionRadius, Vector2.zero, 1f, 6*32);
        

        if (isInteracting && hit == true)
        { 
            if (hit.transform.GetComponent<IInteractable>() != null)
            {
               hit.transform.GetComponent<IInteractable>().Interaction();
            }
        }
    }

    private void Profile()
    {
        bool isOpenningProfile = _gameplayInputActions[2].triggered;

        if (isOpenningProfile)
        {
            UIManager.instance.OpenProfile();

        }
    }

    #endregion
    public void ChangeActionMaps(bool isGameplay)
    {
            if(isGameplay)
            {
                _inputActionMaps[1].Disable();
                _inputActionMaps[0].Enable();
            }
            else
            {
                _inputActionMaps[0].Disable();
                _inputActionMaps[1].Enable();
            }
    }

    
    
}
