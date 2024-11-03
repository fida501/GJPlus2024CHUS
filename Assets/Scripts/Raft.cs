using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    public int woodNeeded = 10;
    public int rockNeeded = 10;
    public int raftPhase = 0;
    public GameObject raftPhase1;
    public GameObject raftPhase2;
    public GameObject raftPhase3;
    

    public void BuildRaft()
    {
        if (GameManager.instance.player.Wood >= woodNeeded && GameManager.instance.player.Rock >= rockNeeded)
        {
            GameManager.instance.player.RemoveWood(woodNeeded);
            GameManager.instance.player.RemoveRock(rockNeeded);
            UIManager.instance.SetWoodText(GameManager.instance.player.Wood);
            UIManager.instance.SetRockText(GameManager.instance.player.Rock);
            raftPhase++;
            CheckRaft();
        }
        else
        {
            Debug.Log("Not enough resources to build raft!");
        }
    }

    public void CheckRaft()
    {
        if (raftPhase == 1)
        {
            raftPhase1.SetActive(true);
        }
        else if (raftPhase == 2)
        {
            raftPhase2.SetActive(true);
        }
        else if (raftPhase == 3)
        {
            raftPhase3.SetActive(true);
            GameManager.instance.WinGame();
        }
    }
}