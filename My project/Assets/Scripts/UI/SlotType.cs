using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotType : MonoBehaviour
{
    [Range(0, 4)]
    [SerializeField] private int _slotType;

    public int GetSlotType {  get { return _slotType; } }
}
