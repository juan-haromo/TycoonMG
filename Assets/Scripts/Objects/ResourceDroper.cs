using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoureceDroper : MonoBehaviour
{

    public GameObject[] resources;
    public float spwanTime;

    private int dropperTier;

    // Start is called before the first frame update
    void Start()
    {
        dropperTier = 1;
        DropResource();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DropResource()
    {
        if (dropperTier<=resources.Length)
        {
            Instantiate(resources[dropperTier - 1], transform.position, resources[dropperTier -1].transform.rotation);
        }

        StartCoroutine(NextResourceDelay());

    }

    IEnumerator NextResourceDelay()
    {
        yield return new WaitForSeconds(spwanTime);
        DropResource();
    }

    public void  UpgradeDroper()
    {
        dropperTier++;
    }
}
