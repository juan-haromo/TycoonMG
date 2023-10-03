using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text resourceText;

    public float currentResources;

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

    public void RemoveResource(float _value)
    {
        currentResources -= _value;
        UpdateUI();
    }

    public float CurrentResourses()
    {
        return currentResources;
    }

    public void UpdateUI()
    {
        if(currentResources > 1000000)
        {
            resourceText.text = "Iron $" + currentResources / 1000000 + "M";
        }
        else if (currentResources > 1000)
        {
            resourceText.text = "Iron $" + currentResources/1000 + "K";
        }
        else
        {
            resourceText.text = "Iron $" + currentResources;
        }
        
    }

}
