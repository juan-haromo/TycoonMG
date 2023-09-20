using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text resourceText;

    private float currentResources;

    // Start is called before the first frame update
    void Start()
    {
        currentResources = 0;
        UpdateUI();
    }

    public void AddResource(float _value)
    {
        currentResources += _value;
        UpdateUI();
    }

    void RemoveResource(float _value)
    {
        currentResources -= _value;
        UpdateUI();
    }

    float CurrentResourses()
    {
        return currentResources;
    }

    public void UpdateUI()
    {
        resourceText.text = "WillyCoins $" + currentResources;
    }

}
