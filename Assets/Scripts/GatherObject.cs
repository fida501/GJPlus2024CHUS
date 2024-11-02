using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherObject : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private string _resourceType;

    public int Amount
    {
        get { return _amount; }
    }

    public string ResourceType
    {
        get { return _resourceType; }
    }
}