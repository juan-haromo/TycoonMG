using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text resourceText;

    public float currentResources;

    private int scenaryNextPrize = 150;
    

    private int conveyerNextPrize = 75;
    private int totalUpgrades = 4;

    private int wallNextPrize = 75;

    private bool isWallDone = false;
    private bool isConveyersDone = false;


    private int actualFloor = 1;
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

    public int GetWallPrize()
    {
        int old = wallNextPrize;
        wallNextPrize += 50 * actualFloor;
        return old;
    } 
    public int GetScenaryPrize()
    {
        int old = scenaryNextPrize;
        scenaryNextPrize += 75 * actualFloor;
        return old;
    } 
    
    public int GetConveyerPrize()
    {
        int old = conveyerNextPrize;
        conveyerNextPrize += 300 * (int)(totalUpgrades/4) * actualFloor;
        totalUpgrades++;
        return old;
    }

    public int GetFloorPrize()
    {
        actualFloor++;
        return conveyerNextPrize *  actualFloor;
    }

    public void DoneConveyers()
    {
        isConveyersDone = true;
    }
    public void DoneWalls()
    {
        isWallDone = true;  
    }

    public bool NextFloorReady()
    {
        return isConveyersDone && isWallDone;
    }

    public void NewFloorCreated()
    {
        isWallDone = false;
        isConveyersDone = false;
    }

}
