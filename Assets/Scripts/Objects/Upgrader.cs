using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{

    private ResourceManager resourceManager;
    public string text;
    private string cost;

    public ObjectType objectType;

    public UnityEvent OnActivated;

    private TextMesh textMesh;
    private float upgradeCost;



    // Start is called before the first frame update
    void Start()
    {

        resourceManager = FindAnyObjectByType<ResourceManager>();
        upgradeCost = objectType == ObjectType.Scenary ? resourceManager.GetScenaryPrize() 
            : objectType == ObjectType.Conveyer ? resourceManager.GetConveyerPrize() 
            : objectType == ObjectType.Wall? resourceManager.GetWallPrize() 
            : resourceManager.GetFloorPrize() ;
        textMesh = GetComponentInChildren<TextMesh>();

        if (upgradeCost > 1000000)
        {
            cost = upgradeCost / 1000000 + "M $";
        }
        else if (upgradeCost > 1000)
        {
            cost = upgradeCost / 1000 + "K $";
        }
        else
        {
            cost =  upgradeCost + "$";
        }

        textMesh.text = text + " " + cost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (resourceManager.CurrentResourses() >= upgradeCost)
            {
                resourceManager.RemoveResource(upgradeCost);
                OnActivated.Invoke();
                Destroy(gameObject);
            }
        }
    }

    public enum ObjectType
    {
        Scenary,
        Conveyer,
        Wall,
        Floor
    };

    public void FinishedWalls()
    {
        resourceManager.DoneWalls();
    }

    public void FinishedConveyers()
    {
        resourceManager.DoneConveyers();
    }
}
