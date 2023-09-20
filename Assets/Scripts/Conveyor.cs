using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Conveyor : MonoBehaviour
{
    public float speed;

    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = transform.forward * speed;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Resource"))
        {
            Transform collidedObject = collision.gameObject.transform;
            collidedObject.position = new Vector3(collidedObject.position.x + movement.x * Time.deltaTime, collidedObject.position.y + movement.y * Time.deltaTime, collidedObject.position.z + movement.z * Time.deltaTime);

        }
    }
}
