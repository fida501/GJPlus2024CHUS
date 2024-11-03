using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject buttonGatherResource;
    public GameObject buttonBuildRaft;
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
        if (GameManager.instance.playerController.isMoving || GameManager.instance.playerController.isGathering)
        {
            return;
        }

        if (GameManager.instance.playerDetector._gatherableList.Count < 1)
        {
            return;
        }

        // GameObject objectToGather = GameManager.instance.playerDetector._gatherableList[0];
        GameObject objectToGather = CheckClosestGatherable(GameManager.instance.playerDetector._gatherableList);
        GatherObject gatherObject = objectToGather.GetComponent<GatherObject>();
        GameManager.instance.playerController.SetCanMove(false);
        GameManager.instance.playerController.FaceTarget(objectToGather);
        GameManager.instance.gatherObjectGameObject = objectToGather;
        if (gatherObject.ResourceType == "Batu")
        {
            GameManager.instance.playerController.StartLootingAnimation();
        }
        else if (gatherObject.ResourceType == "Kayu")
        {
            GameManager.instance.playerController.StartPunchingAnimation();
        } else
        {
            GameManager.instance.playerController.SetCanMove(true);
            Debug.Log("Resource type not found");
            return;
        }

        GameManager.instance.playerDetector._gatherableList.Remove(objectToGather);
    }

    public GameObject CheckClosestGatherable(List<GameObject> gatherableList)
    {
        GameObject closestGatherable = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject gatherable in gatherableList)
        {
            float distance = Vector3.Distance(GameManager.instance.playerController.transform.position,
                gatherable.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestGatherable = gatherable;
            }
        }

        return closestGatherable;
    }
    
    public void BuildRaft()
    {
        if (GameManager.instance.playerController.isMoving || GameManager.instance.playerController.isGathering)
        {
            return;
        }

        GameManager.instance.playerController.SetCanMove(false);
        GameManager.instance.raft.BuildRaft();
        GameManager.instance.playerController.SetCanMove(true);
    }
}