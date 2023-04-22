using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public static class GameData
{
    private static int _gold = 0;
    private static int _crystal = 0;
    private static int _currentLevel = 0;
    private static int _energy = 0;
    private static int[] _levels;

    static GameData()
    {
        _gold = PlayerPrefs.GetInt("Gold", 2000);
        _crystal = PlayerPrefs.GetInt("Crystal", 250);
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        _energy = PlayerPrefs.GetInt("Energy", 30);
        _levels = new int[5];
        _levels[0] = 1;
        _levels[1] = 1;
    }

    public static int Gold
    {
        get { return _gold; }
        set { PlayerPrefs.SetInt("Gold", (_gold = value)); }
    }

    public static int Crystal
    {
        get { return _crystal; }
        set { PlayerPrefs.SetInt("Crystal", (_crystal = value)); }
    }

    public static int CurrentLevel
    {
        get { return _currentLevel; }
        set { PlayerPrefs.SetInt("CurrentLevel", (_currentLevel = value)); }
    }
    public static int Energy
    {
        get { return _energy; }
        set { PlayerPrefs.SetInt("Energy", (_energy = value)); }
    }
    public static int Levels
    {
        get { return _levels[0]; }
        set {
            LoadLevelStatus();
            UnlockLevel(value);
            SaveLevelStatus();  }
    }

    public static void SaveLevelStatus()
    {
        string levelData = "";
        for (int i = 0; i < _levels.Length; i++)
        {
            levelData += _levels[i] + " ";
        }
        File.WriteAllText(Application.persistentDataPath + "/levelStatus.txt", levelData);
    }
    private static void LoadLevelStatus()
    {
        string path = Application.persistentDataPath + "/levelStatus.txt";
        if (File.Exists(path))
        {
            string levelData = File.ReadAllText(path);
            string[] levelDataArray = levelData.Split(' ');

            for (int i = 0; i < _levels.Length; i++)
            {
                _levels[i] = int.Parse(levelDataArray[i]);
            }
        }
        else
        {
            _levels = new int[_levels.Length];
            for (int i = 0; i < _levels.Length; i++)
            {
                _levels[i] = i == 0 ? 1 : 0;
            }
            GameData.SaveLevelStatus();
        }
    }
    public static void UnlockLevel(int level)
    {
        _levels[level] = 1;
        SaveLevelStatus();
    }
    public static bool IsLevelUnlocked(int level)
    {
        return _levels[level] == 1;
    }
    public static void UpdateDataText()
    {
        
        Text gold_text = GameObject.Find("CurrentGoldText").GetComponent<Text>();
        Text crystal_text = GameObject.Find("CurrentCrystalText").GetComponent<Text>();
        Text energy_text = GameObject.Find("CurrentEnergyText").GetComponent<Text>();
        gold_text.text = _gold.ToString();
        crystal_text.text = _crystal.ToString();
        energy_text.text = string.Format("{0}/{1}", _energy, 30);
    }
}