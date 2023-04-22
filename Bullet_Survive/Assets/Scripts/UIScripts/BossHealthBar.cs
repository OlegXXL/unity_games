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
                GameData.Levels = SceneManager.GetActiveScene().buildIndex;
                Debug.Log("COMPLETEEEEEE");
            }
        }
        
        if (boss) line.sizeDelta = new Vector2(maxWidth / boss.maxHealth * boss.health, line.sizeDelta.y);
        else line.sizeDelta = new Vector2(maxWidth / 2, line.sizeDelta.y);
    }
}
