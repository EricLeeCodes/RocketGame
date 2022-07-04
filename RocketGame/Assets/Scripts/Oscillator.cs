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

    [SerializeField] float period = 5f;


    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }



    void Update()
    {
        //if period is 0 don't do anything
        if (period <= Mathf.Epsilon) { return; }

        //Time divided by period
        //Continually growing over time
        float cycles = Time.time / period;

        //tau is 2pi.
        //const is a constant variable that is never changing.
        const float tau = Mathf.PI * 2;

        //Going from -1 to 1
        float rawSinWave = Mathf.Sin(cycles * tau);

        
        //Making a range from 0 to 1 to look cleaner
        //Logic: rawSinWave goes from -1 to 1. ((-1 + 1) / 2) and ((1 + 1) / 2)
        movementFactor = (rawSinWave + 1f) / 2f;


        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
