using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject buyNextFloor;

    private ResourceManager resourceManager;

    public Transform floorPos;

    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
     resourceManager = FindObjectOfType<ResourceManager>();   
    }

    public void NewFloor()
    {
        Vector3 nextFloorpos = floorPos.position;
        nextFloorpos.y += 5.0f;
        Instantiate(floor,nextFloorpos, floor.transform.rotation);    
    }

    public void NextFloor()
    {
        if (resourceManager.NextFloorReady())
        {
            resourceManager.NewFloorCreated();
            buyNextFloor.SetActive(true);
        }
    }

}
