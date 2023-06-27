using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private float maxWidth = 670;
    public EnemyController boss;
    private RectTransform line;
    [SerializeField] private ResultGame _resultGame;
    private int curentLevel;
    void Start()
    {
        line = GameObject.Find("BossHealthLine").GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!boss)
        {
            boss = GameObject.FindGameObjectWithTag("Boss")?.GetComponent<EnemyController>();
        }
    }
    bool a = true;

    void FixedUpdate()
    {
        if (boss)
        {
            if (boss.health <= 0 && a)
            {
                a = false;
                _resultGame.GameFinish("win", "1:25", 8, 100);
                curentLevel = int.Parse(SceneManager.GetActiveScene().name);
                if(curentLevel > PlayerPrefs.GetInt("UnlockedLevel"))
                    PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel") + 1);
                Debug.Log("COMPLETEEEEEE");
            }
        }
        
        if (boss) line.sizeDelta = new Vector2(maxWidth / boss.maxHealth * boss.health, line.sizeDelta.y);
        else line.sizeDelta = new Vector2(maxWidth / 2, line.sizeDelta.y);
    }
}
