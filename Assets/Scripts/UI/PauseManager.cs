using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused;
    [SerializeField] CameraController cameraController;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Slider sensivitySlider;
    [SerializeField] GameObject tablet;
    [SerializeField] GameObject pauseExample;


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        CursorState(false);
        sensivitySlider.value = cameraController.sensivity;
    }

    // Update is called once per frame
    void Update()
    {
        PauseInput();   
    }

    void PauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !(tablet.activeSelf))
        {
            pauseExample.SetActive(false);
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PausedGame();
            }
        }
    }

    void PausedGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        CursorState(true);
        playerMovement.canMove = false;
        cameraController.canRotate = false;

    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        CursorState(false);
        playerMovement.canMove = true;
        cameraController.canRotate = true;
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

    public void SetSensibility()
    {
        cameraController.sensivity = sensivitySlider.value;
    }
}
