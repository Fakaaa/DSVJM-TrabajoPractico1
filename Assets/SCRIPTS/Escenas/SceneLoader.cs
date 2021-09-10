using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;

    public static SceneLoader Get()
    {
        return instance;
    }

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        Scene auxSene = SceneManager.GetSceneByName(sceneName);
        if(auxSene != null)
            SceneManager.LoadScene(sceneName);
    }
    public void LoadScene(int indexScene)
    {
        Scene auxSene = SceneManager.GetSceneByBuildIndex(indexScene);
        if(auxSene != null)
            SceneManager.LoadScene(indexScene);
    }
}
