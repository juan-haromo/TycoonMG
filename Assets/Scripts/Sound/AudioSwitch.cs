using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AudioSwitch : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClips;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound()
    {
        int randomIndex = Random.Range(0, audioClips.Count);
        audioSource.PlayOneShot(audioClips[randomIndex]);
        yield return new WaitForSeconds(audioClips[randomIndex].length);
        StartCoroutine(PlaySound());
    }
}
