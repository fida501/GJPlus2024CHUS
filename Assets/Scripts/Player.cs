using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int wood = 0;

    public int Wood
    {
        get { return wood; }
        set { wood = value; }
    }

    public void AddWood(int amount)
    {
        wood += amount;
    }

    public void RemoveWood(int amount)
    {
        wood -= amount;
    }
}