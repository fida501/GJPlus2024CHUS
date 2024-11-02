using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public List<GameObject> _gatherableList = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gatherable"))
        {
            _gatherableList.Add(other.gameObject);
            ButtonManager.instance.buttonGatherResource.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var gatherable in _gatherableList)
        {
            if (gatherable == other.gameObject)
            {
                _gatherableList.Remove(gatherable);
                break;
            }
        }

        if (_gatherableList.Count == 0)
        {
            ButtonManager.instance.buttonGatherResource.SetActive(false);
        }
    }
}