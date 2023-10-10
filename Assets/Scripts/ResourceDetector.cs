using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    private ResourceManager resourceManager;

    private void Start()
    {
        resourceManager = FindAnyObjectByType<ResourceManager>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Resource>()){
            resourceManager.AddResource(other.gameObject.GetComponent<Resource>().value);
            Destroy((other.gameObject));
        }
    }
}
