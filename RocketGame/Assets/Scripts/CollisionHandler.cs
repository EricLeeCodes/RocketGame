using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{



    private void OnCollisionEnter(Collision collision)
    {

        string collides = collision.gameObject.tag;


        switch (collides)
        {
            case "Friendly":
                Debug.Log("This thing is friendly!");
                break;
            case "Fuel":
                Debug.Log("You've gained more fuel!");
                break;
            case "Finish":
                NextLevel();
                break;
            default:
                ReloadLevel();
                break;
        }
    }



    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Debug.Log("You've hit the ground and exploded!");
    }
    void NextLevel()
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
