using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private float maxWidth = 670;
    public EnemyController boss;
    private RectTransform line;

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

    void FixedUpdate()
    {
        if (boss) line.sizeDelta = new Vector2(maxWidth / boss.maxHealth * boss.health, line.sizeDelta.y);
        else line.sizeDelta = new Vector2(maxWidth / 2, line.sizeDelta.y);
    }
}
