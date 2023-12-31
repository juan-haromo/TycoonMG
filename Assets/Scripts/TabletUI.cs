using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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
    [SerializeField] CameraController cameraControlls;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject tabletExample;
 
    // Start is called before the first frame update

    private void Start()
    {

        UI.gameObject.SetActive(true);
        resourceManager = FindObjectOfType<ResourceManager>();
        upgradeGenerateButtonText.text = "Update click " + clickGeneratorCost + "$";
        generateButtonText.text = "Generate " + clickResource + "$";
        UI.gameObject.SetActive(false);
        playerMovement.canMove = true;
        cameraControlls.canRotate = true;
        
        
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && !(pauseMenu.activeSelf))
        {
            tabletExample.SetActive(false); 
            CursorState(!UI.activeSelf);
            UI.gameObject.SetActive(!UI.activeSelf);
            playerMovement.canMove = !(playerMovement.canMove);
            cameraControlls.canRotate = !(cameraControlls.canRotate);
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

    public void CursorState(bool state)
    {
        Cursor.visible = state;
        if (state)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
