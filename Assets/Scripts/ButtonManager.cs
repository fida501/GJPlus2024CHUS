using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject buttonGatherResource;

    public static ButtonManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void GatherResource()
    {
        if (GameManager.instance.playerController.isMoving)
        {
            return;
        }
        if (GameManager.instance.playerDetector._gatherableList.Count < 1)
        {
            return;
        }
        
        GameObject objectToGather = GameManager.instance.playerDetector._gatherableList[0];
        GatherObject gatherObject = objectToGather.GetComponent<GatherObject>();
        GameManager.instance.playerController.SetCanMove(false);
        GameManager.instance.playerController.FaceTarget(objectToGather);
        if (gatherObject.ResourceType == "Batu")
        {
            GameManager.instance.gatherObjectGameObject = objectToGather;
            GameManager.instance.playerController.StartLootingAnimation();
        }
        else if (gatherObject.ResourceType == "Kayu")
        {
            // GameManager.instance.player.AddWood(gatherObject.Amount);
            // UIManager.instance.SetWoodText(GameManager.instance.player.Wood);
        }
        GameManager.instance.playerDetector._gatherableList.Remove(objectToGather);
    }
}