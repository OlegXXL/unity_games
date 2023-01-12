using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
    public static float progress = 0;
    [SerializeField] private float endTime = 300;
    [SerializeField] private float maxWidth = 670;
    private RectTransform line;

    void Start()
    {
        progress = 0;
        line = GameObject.Find("Line").GetComponent<RectTransform>();
        Debug.Log(line);
        InvokeRepeating("Timer", 1f, 1f);
    }

    void Timer()
    {
        if (progress >= 100) return;
        progress += 100 / endTime;
        if (progress >= 100) GetComponentInParent<Animator>().SetBool("TimeEnded", true);
    }

    void FixedUpdate()
    {
        line.sizeDelta = new Vector2(maxWidth / 100 * progress, line.sizeDelta.y);
    }
}
