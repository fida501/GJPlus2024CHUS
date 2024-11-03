using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController playerController;
    public Player player;
    public PlayerDetector playerDetector;
    public GameObject gatherObjectGameObject;
    public Raft raft;
    public string GameStatus = "Playing";
    public GameObject winUI;
    public GameObject loseUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectObject()
    {
        GatherObject gatherObject = gatherObjectGameObject.GetComponent<GatherObject>();
        if (gatherObject.ResourceType == "Batu")
        {
            player.AddRock(gatherObject.Amount);
            UIManager.instance.SetRockText(player.Rock);
        }
        else if (gatherObject.ResourceType == "Kayu")
        {
            player.AddWood(gatherObject.Amount);
            UIManager.instance.SetWoodText(player.Wood);
        }
    }

    //Win Game Function, wait for 10 seconds before win the game\
    public void WinGame()
    {
        GameStatus = "Win";
        StartCoroutine(WinGameCoroutine());
    }

    private IEnumerator WinGameCoroutine()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("You Win!");
        //Show Win UI
        winUI.SetActive(true);
    }

    //Lose Game Function, wait for 10 seconds before lose the game

    public void LoseGame()
    {
        GameStatus = "Lose";
        StartCoroutine(LoseGameCoroutine());
    }

    private IEnumerator LoseGameCoroutine()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("You Lose!");
        //Show Lose UI
        loseUI.SetActive(true);
    }
}