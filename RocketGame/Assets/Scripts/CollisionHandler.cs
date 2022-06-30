using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {

        string collides = collision.gameObject.tag;

        //If isTransitioning, don't continue to the switch statement.
        if (isTransitioning == true) { return; }

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
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        Invoke("ReloadLevel", delayTime);
        GetComponent<Movement>().enabled = false;
    }

    void StartingNextSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
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
