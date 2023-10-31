using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabletUI : MonoBehaviour
{
    private ResourceManager resourceManager;
    private float clickResource = 5.0f;
    [SerializeField] private GameObject UI;
    private CameraController cameraController;
    public TMP_Text generateButtonText;
    public TMP_Text upgradeGenerateButtonText;
    private int clickGeneratorCost = 100;
    [SerializeField] PlayerMovement playerMovement;
    // Start is called before the first frame update

    private void Start()
    {
        UI.gameObject.SetActive(false);
        resourceManager = FindObjectOfType<ResourceManager>();
        upgradeGenerateButtonText.text = "Update click " + clickGeneratorCost + "$";
        generateButtonText.text = "Generate " + clickResource + "$";

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UI.gameObject.SetActive(!UI.activeSelf);
            playerMovement.canMove = !(playerMovement.canMove); 
            playerMovement.Stop();
        }
    }
    public void GenerateResourece()
    {
        resourceManager.AddResource(clickResource);
    }

    public void UpdateClicker()
    {
        if (resourceManager.currentResources > clickGeneratorCost)
        {
            resourceManager.RemoveResource(clickGeneratorCost);
            clickResource *= 5;
            clickGeneratorCost *= 10;

            string clickCost = clickGeneratorCost > 1000000 ? clickGeneratorCost / 1000000 + "M$" : clickGeneratorCost > 1000 ? clickGeneratorCost / 1000 + "K$" : clickGeneratorCost + "$";
            string clickGenerate = clickResource > 1000000 ? clickResource / 1000000 + "M$" : clickResource > 1000 ? clickResource / 1000 + "K$" : clickResource + "$";


            upgradeGenerateButtonText.text = "Update click " + clickCost;
            generateButtonText.text = "Generate " + clickGenerate;
        }
        
    }

}
