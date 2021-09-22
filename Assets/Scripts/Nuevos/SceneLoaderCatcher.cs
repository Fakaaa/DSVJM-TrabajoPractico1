using UnityEngine;

public class SceneLoaderCatcher : MonoBehaviour
{
    [HideInInspector] public SceneLoader slReference;

    void Awake()
    {
        slReference = FindObjectOfType<SceneLoader>();
    }

    public void SetSinglePlayer()
    {
        if(slReference != null)
            slReference.SetGameModeSinglePlayer();
    }

    public void SetMultiPlayer()
    {
        if(slReference != null)
            slReference.SetGameModeMultiPlayer();
    }

    public void SetEasy()
    {
        if(slReference != null)
            slReference.SetDifficultyEasy();
    }

    public void SetNormal()
    {
        if(slReference != null)
            slReference.SetDifficultyNormal();
    }

    public void SetHard()
    {
        if(slReference != null)
            slReference.SetDifficultyHard();
    }

    public void LoadLevel()
    {
        if (slReference != null)
            slReference.LoadLevel();
    }

    public void LoadScene(string sceneName)
    {
        if (slReference != null)
            slReference.LoadScene(sceneName);
    }
}
