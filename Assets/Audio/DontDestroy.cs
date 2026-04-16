using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public string sceneToDestroyIn;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks when the object is finally destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == sceneToDestroyIn)
        {
            // Destroy the object if the target scene is loaded
            Destroy(this.gameObject);
        }
    }
}
