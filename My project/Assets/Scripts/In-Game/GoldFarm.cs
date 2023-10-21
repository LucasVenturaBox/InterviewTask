using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldFarm : MonoBehaviour, IInteractable
{
    public void Interaction()
    {
        GameManager.instance.IncrementRandomCoins(3, 10);
    }

}
