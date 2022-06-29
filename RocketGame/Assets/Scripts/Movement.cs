using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {

            //Vector3 is 3 values of vectors (x, y, z)
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime) ;


            //Audio
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }



    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            ApplyRotation(-rotationThrust);
        }

        


    }

    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //Unfreezing rotation so that physics system can take over.
    }




} 
