using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public float movementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x < -27f)
        {
            Destroy(gameObject);
        }
    }
}