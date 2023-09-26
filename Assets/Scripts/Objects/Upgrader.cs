using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{

    public ResourceManager resourcemanager;
    public float upgradeCost;
    public string text;

    public UnityEvent OnActivated;

    private TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();

        textMesh.text = text + " $ " + upgradeCost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (resourcemanager.CurrentResourses() >= upgradeCost)
            {
                resourcemanager.RemoveResource(upgradeCost);
                OnActivated.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
