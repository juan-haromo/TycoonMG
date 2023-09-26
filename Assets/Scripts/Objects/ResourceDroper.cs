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
        InvokeRepeating("DropResource", spwanTime,spwanTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DropResource()
    {
        if (resources[dropperTier] != null || dropperTier<=resources.Length)
        {
            Instantiate(resources[dropperTier - 1], transform.position, Quaternion.identity);
        }
    }

    public void  UpgradeDroper()
    {
        dropperTier++;
    }
}
