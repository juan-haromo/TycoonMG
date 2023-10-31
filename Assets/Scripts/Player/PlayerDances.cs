using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDances : MonoBehaviour
{
    [SerializeField] Animator playerAnimation;
    private ResourceManager resourceManager;
    [SerializeField] private GameObject dance;

    // Start is called before the first frame update
    private void Start()
    {
        playerAnimation.SetFloat("Dance", 1);
        resourceManager = FindObjectOfType<ResourceManager>();  
    }

    public void SetDance(int dance)
    {
        playerAnimation.SetFloat("Dance", dance);
    }

    public void BuyDance(float cost)
    {
        if (resourceManager.CurrentResourses() >= cost){
            resourceManager.RemoveResource(cost);
            dance.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
