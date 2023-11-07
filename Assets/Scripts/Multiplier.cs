using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public float multiplier;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Resource>())
        {
            other.gameObject.GetComponent<Resource>().value *= multiplier;
        }
    }
}
