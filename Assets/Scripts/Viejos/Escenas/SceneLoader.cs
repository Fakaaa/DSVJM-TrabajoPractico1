using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader Instance;

    [System.Serializable]
    public enum GameDifficulty { Easy, Normal, Hard}
    public GameDifficulty gameDifficulty;

    [System.Serializable]
    public enum GameMode { Single, Multi}
    public GameMode gMode;

    public string singlePlayerSceneName;
    public string multiPlayerSceneName;

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

    public void LoadLevel()
    {
        switch (gMode)
        {
            case GameMode.Single:   LoadScene(singlePlayerSceneName);
                break;
            case GameMode.Multi:    LoadScene(multiPlayerSceneName);
                break;
        }
    }

    public void LoadScene(int indexScene)
    {
        Scene AuxSene = SceneManager.GetSceneByBuildIndex(indexScene);
        if(AuxSene != null)
            SceneManager.LoadScene(indexScene);
    }

    public void SetGameModeSinglePlayer()
    {
        gMode = GameMode.Single;
    }

    public void SetGameModeMultiPlayer()
    {
        gMode = GameMode.Multi;
    }

    public void SetDifficultyEasy()
    {
        gameDifficulty = GameDifficulty.Easy;
    }

    public void SetDifficultyNormal()
    {
        gameDifficulty = GameDifficulty.Normal;
    }

    public void SetDifficultyHard()
    {
        gameDifficulty = GameDifficulty.Hard;
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
