using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisable = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {   //Optional cheatcodes
        //DebugKeys();
    }

    //Optional cheatcodes
    //void DebugKeys()
    //{
    //    if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        LoadNextLevel();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        collisionDisable = !collisionDisable;
    //    }
    //}



    private void OnCollisionEnter(Collision collision)
    {

        string collides = collision.gameObject.tag;

        //If isTransitioning, don't continue to the switch statement.
        if (isTransitioning == true || collisionDisable == true) { return; }

        switch (collides)
        {
            case "Friendly":
                Debug.Log("This thing is friendly!");
                break;
            case "Fuel":
                Debug.Log("You've gained more fuel!");
                break;
            case "Finish":
                StartingNextSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }


    void StartCrashSequence()
    {
        isTransitioning = true;
        //Audio
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        //Particles
        crashParticles.Play();
        //Delay
        Invoke("ReloadLevel", delayTime);
        GetComponent<Movement>().enabled = false;
    }

    void StartingNextSequence()
    {
        isTransitioning = true;
        //Audio
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
        //Particles
        successParticles.Play();
        //Delay
        Invoke("LoadNextLevel", delayTime);
        GetComponent<Movement>().enabled = false;
    }


    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Debug.Log("You've hit the ground and exploded!");
    }
    void LoadNextLevel()
    {
        Debug.Log("You've finished this level!!");
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentScene + 1;
        //If the next scene is equal to the last Scene Count, load back the first level.
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

    }
}
