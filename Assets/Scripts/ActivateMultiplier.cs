using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ActivateMultiplier : MonoBehaviour
{
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] GameObject multiplier;

    
    public void Activate(float cost)
    {
        if (cost < resourceManager.CurrentResourses())
        {
            resourceManager.RemoveResource(cost);
            multiplier.SetActive(true);
            StartCoroutine(MultilpierDuration());
        }
    }

    IEnumerator MultilpierDuration()
    {
        yield return new WaitForSeconds(2.0f);
        multiplier.SetActive(false);
    }
}
