using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour, IInteractable
{
    public void Interaction()
    {
        GameManager.instance.IncrementRandomCoins(5, 10);
    }
}
