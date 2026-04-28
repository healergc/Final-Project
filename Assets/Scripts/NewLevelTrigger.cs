using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevelTrigger : MonoBehaviour
{
    public string LevelToLoad = "NewScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("I Have Found A Player");
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}