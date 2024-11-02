using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int wood = 0;
    [SerializeField] private int rock = 0;

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
    
    public int Rock
    {
        get { return rock; }
        set { rock = value; }
    }
    
    public void AddRock(int amount)
    {
        rock += amount;
    }
    
    public void RemoveRock(int amount)
    {
        rock -= amount;
    }
}