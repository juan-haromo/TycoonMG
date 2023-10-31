using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBooster : MonoBehaviour
{
    public float multiplier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Resource>() != null)
        {
            other.gameObject.GetComponent<Resource>().value *= multiplier;
        }
    }

}
