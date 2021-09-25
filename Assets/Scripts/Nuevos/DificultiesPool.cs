using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultiesPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public SceneLoader.GameDifficulty tagDificulty;
        public GameObject goAttach;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<SceneLoader.GameDifficulty, Queue<GameObject>> poolDictonary;

    static DificultiesPool instance;

    public static DificultiesPool Instance
    {
        get
        {
            if(instance == null)
                instance = FindObjectOfType<DificultiesPool>();

            return instance;
        }
    }

    void Start()
    {
        poolDictonary = new Dictionary<SceneLoader.GameDifficulty, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                if(pool.goAttach != null)
                    pool.goAttach.SetActive(false);

                objectPool.Enqueue(pool.goAttach);
            }

            poolDictonary.Add(pool.tagDificulty, objectPool);
        }
    }

    public void ActivateObstacles(SceneLoader.GameDifficulty dificultie)
    {
        if (!poolDictonary.ContainsKey(dificultie))
        {
            Debug.LogWarning("Pool with tag " + dificultie.ToString() + "does not exist");
            return;
        }

        GameObject obstacles = poolDictonary[dificultie].Dequeue();

        obstacles.SetActive(true);

        poolDictonary[dificultie].Enqueue(obstacles);
    }
}
