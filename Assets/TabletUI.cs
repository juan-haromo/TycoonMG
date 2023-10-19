using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletUI : MonoBehaviour
{
    private ResourceManager resourceManager;
    private float clickResource = 5.0f;
    [SerializeField] private GameObject UI;
    private CameraController cameraController;
    // Start is called before the first frame update

    private void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UI.gameObject.SetActive(!UI.activeSelf);
        }
    }
    public void GenerateResourece()
    {
        resourceManager.AddResource(clickResource);
    }
}
