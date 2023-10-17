using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{

    private ResourceManager resourceManager;
    public string text;

    public ObjectType objectType;

    public UnityEvent OnActivated;

    private TextMesh textMesh;
    private float upgradeCost;



    // Start is called before the first frame update
    void Start()
    {

        resourceManager = FindAnyObjectByType<ResourceManager>();
        upgradeCost = objectType == ObjectType.Scenary ? resourceManager.GetScenaryPrize() : objectType == ObjectType.Conveyer ? resourceManager.GetConveyerPrize() : resourceManager.GetWallPrize(); ;
        textMesh = GetComponentInChildren<TextMesh>();

        textMesh.text = text + " $ " + upgradeCost;
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
        Wall
    };


}
