using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounterController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI tmp;
    void Start()
    {
        if (!PlayerPrefs.HasKey("LevelDeathCount"))
        {
            PlayerPrefs.SetInt("LevelDeathCount", 0);
        }
    }

    void Update()
    {
        tmp.text = PlayerPrefs.GetInt("LevelDeathCount") + "";
    }
}
