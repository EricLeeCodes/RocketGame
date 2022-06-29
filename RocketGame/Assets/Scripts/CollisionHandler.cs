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
                Debug.Log("You've finished the game!!");
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

}
