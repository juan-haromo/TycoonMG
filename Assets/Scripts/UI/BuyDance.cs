using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDance : MonoBehaviour
{
    [SerializeField] GameObject danceButton;
    private ResourceManager resourceManager;

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }
    public void BuyDances(int cost)
    {
        if (resourceManager.currentResources > cost)
        {
            resourceManager.RemoveResource(cost);
            danceButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
