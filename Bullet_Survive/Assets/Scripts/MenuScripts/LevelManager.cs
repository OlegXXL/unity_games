using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int[] levels;
    [SerializeField] GameObject contetntLevels;
    private List<GameObject> statusLocks = new List<GameObject>();
    private void Awake()
    {
        UpdateListLevel();
    }
    private void Start()
    {
        LoadLevelStatus();
        for (int i = 0; i < levels.Length; i++)
        {
            if (i < UnityEditor.EditorBuildSettings.scenes.Length - 1)
            {
                Debug.Log(i);
                if (levels[i] == 1)
                {
                    statusLocks[i].SetActive(false);
                }
                else
                {
                    statusLocks[i].SetActive(true);
                }
            }
        }
    }
    private void UpdateListLevel() 
    {
        for (int i = 0; i < contetntLevels.transform.childCount; i++)
        {
            contetntLevels.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
            statusLocks.Add(contetntLevels.transform.GetChild(i).transform.GetChild(0).gameObject);
        }
    }

    private void LoadLevelStatus()
    {
        string path = Application.persistentDataPath + "/levelStatus.txt";
        if (File.Exists(path))
        {
            string levelData = File.ReadAllText(path);
            string[] levelDataArray = levelData.Split(' ');

            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = int.Parse(levelDataArray[i]);
            }
        }
        else
        {
            levels = new int[levels.Length];
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = i == 0 ? 1 : 0;
            }
            SaveLevelStatus();
        }
    }

    private void SaveLevelStatus()
    {
        string levelData = "";
        for (int i = 0; i < levels.Length; i++)
        {
            levelData += levels[i] + " ";
        }
        File.WriteAllText(Application.persistentDataPath + "/levelStatus.txt", levelData);
    }

    public void UnlockLevel(int level)
    {
        levels[level] = 1;
        SaveLevelStatus();
    }

    public void LockLevel(int level)
    {
        levels[level] = 0;
        SaveLevelStatus();
    }

    public bool IsLevelUnlocked(int level)
    {
        return levels[level] == 1;
    }
}