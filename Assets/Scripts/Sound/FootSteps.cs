using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] List<AudioClip> footSteps;
    [SerializeField] AudioSource stepSource;
    [SerializeField] float minPitch;
    [SerializeField] float maxPitch;

   public void FootStep()
    {
        stepSource.pitch = Random.Range(minPitch, maxPitch);
        int randomIndex = Random.Range(0, footSteps.Count);
        stepSource.PlayOneShot(footSteps[randomIndex]);
    }
}
