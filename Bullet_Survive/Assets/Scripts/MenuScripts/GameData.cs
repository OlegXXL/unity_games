using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class GameData
{
    private static int _gold = 0;
    private static int _crystal = 0;
    private static int _currentLevel = 0;
    private static int _energy = 0;

    static GameData()
    {
        _gold = PlayerPrefs.GetInt("Gold", 2000);
        _crystal = PlayerPrefs.GetInt("Crystal", 250);
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        _energy = PlayerPrefs.GetInt("Energy", 30);
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