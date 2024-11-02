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
        if(gatherObject.ResourceType == "Batu")
        {
            player.AddRock(gatherObject.Amount);
            UIManager.instance.SetRockText(player.Rock);
        }
        else if(gatherObject.ResourceType == "Kayu")
        {
            player.AddWood(gatherObject.Amount);
            UIManager.instance.SetWoodText(player.Wood);
        }
    }
}
