using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 50f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainThrusterParticles;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;


    

    Rigidbody rb;
    AudioSource audioSource;


    
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        //Vector3 is 3 values of vectors (x, y, z)
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        //Thrust Particle

        //Audio
        if (audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (mainThrusterParticles.isPlaying == false)
        {
            mainThrusterParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainThrusterParticles.Stop();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (leftThrusterParticles.isPlaying == false)
        {
            leftThrusterParticles.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (rightThrusterParticles.isPlaying == false)
        {
            rightThrusterParticles.Play();
        }
    }

    void StopRotating()
    {
        leftThrusterParticles.Stop();
        rightThrusterParticles.Stop();
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //Unfreezing rotation so that physics system can take over.
    }





} 




