using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRotator : MonoBehaviour
{   
    float rotationSpeed = 5f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
