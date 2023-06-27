using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private GameObject contetntLevels;
    private List<GameObject> statusLocks = new List<GameObject>();
    private int currentUnlockedLevel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        currentUnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel");
        if (PlayerPrefs.HasKey("FirstOnGame") == false)
        {
            PlayerPrefs.SetInt("FirstOnGame", 1);
            PlayerPrefs.SetInt($"UnlockedLevel", 1);
            UpdateListLevel();
        }
        else
        {            
            UpdateListLevel();
        }
        
    }
    private void Start()
    {
        
    }
    private void SetAllBckStatus()
    {
        for (int i = 0; i < contetntLevels.transform.childCount; i++)
        {
            Debug.Log(i);
            if (i <= currentUnlockedLevel)
            {
                statusLocks[i].SetActive(false);
            }
            else
            {
                statusLocks[i].SetActive(true);
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
        SetAllBckStatus();
    }

}