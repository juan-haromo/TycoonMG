using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    public ResourceManager resourceManager;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Resource>()){
            resourceManager.AddResource(other.gameObject.GetComponent<Resource>().value);
        }
    }
}
