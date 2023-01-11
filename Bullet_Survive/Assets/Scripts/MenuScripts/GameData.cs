using UnityEngine;

public static class GameData
{
    private static int _gold = 0;
    private static int _crystal = 0;
    private static int _currentLevel = 0;

    static GameData()
    {
        _gold = PlayerPrefs.GetInt("Gold", 0);
        _crystal = PlayerPrefs.GetInt("Crystal", 0);
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
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
}