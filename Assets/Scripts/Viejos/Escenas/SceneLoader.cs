using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader Instance;

    [System.Serializable]
    public enum GameDifficulty { Easy, Medium, Hard}
    public GameDifficulty gameDifficulty;

    [System.Serializable]
    public enum GameMode { Single, Multi}
    public GameMode gMode;

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

    public void SetGameMode(GameMode gameMode)
    {
        gMode = gameMode;
    }

    public void SetGameDifficulty(GameDifficulty difficulty)
    {
        gameDifficulty = difficulty;
    }

    public GameMode GetActualMode()
    {
        return gMode;
    }

    public GameDifficulty GetActualDifficulty()
    {
        return gameDifficulty;
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
         Application.Quit();
    #endif
    }
}
