using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader Instance;

    public static SceneLoader Get()
    {
        return Instance;
    }

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        Scene AuxSene = SceneManager.GetSceneByName(sceneName);
        if(AuxSene != null)
            SceneManager.LoadScene(sceneName);
    }
    public void LoadScene(int indexScene)
    {
        Scene AuxSene = SceneManager.GetSceneByBuildIndex(indexScene);
        if(AuxSene != null)
            SceneManager.LoadScene(indexScene);
    }
}
