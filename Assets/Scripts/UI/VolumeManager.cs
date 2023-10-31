using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    

    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = AudioListener.volume;
    }

    public void ChamgeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
