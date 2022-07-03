using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;

    [Range(0, 1)]
    [SerializeField]  
    float movementFactor;



    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }



    void Update()
    {
        Vector3 offset = movementVector * movementFactor;
    }
}
