using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private PlayerController _playerController;
    private string currentState;

    private void Awake()
    {
        _animator = GetComponent<Animator>();   
         _playerController = GetComponent<PlayerController>();
        
    }

    private void Update()
    {
        Vector2 direction = _playerController.GetCurrentDirection;
        bool interact = _playerController.GetCurrentInteract;

        Debug.Log(direction);
        if (direction.y > 0)
        {

            ChangeCurrentState("Walk Up State");
            Debug.Log("Inside the if");
        }
        else if (direction.y < 0)
        {
            ChangeCurrentState("Walk Down State");

        }
        else if( direction.x < 0)
        {
            ChangeCurrentState("Walk Left State");

        }
        else if (direction.x > 0)
        {
            ChangeCurrentState("Walk Right State");
        }
        else if ( direction.x == 0) 
        {
            ChangeCurrentState("Idle");
        }

        if(interact)
        {
            ChangeCurrentState("Work State");
        }
    }

    private void ChangeCurrentState(string newState)
    {
        if(currentState == newState) 
        { 
            return; 
        }

        _animator.Play(newState);
        
        

        currentState = newState;
    }
}
