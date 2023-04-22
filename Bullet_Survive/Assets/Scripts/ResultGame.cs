using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ResultGame : MonoBehaviour
{
    [SerializeField] GameObject panelEndLevel;
    [SerializeField] GameObject circleBack;
    [SerializeField] GameObject playerInCircle;
    [SerializeField] Sprite losePlayerInCircle;
    [SerializeField] Sprite loseCircle;

    [Header ("Data statistics text for animation")]
    [SerializeField] Text levelName_Txt;
    [SerializeField] Text timeFinished_Txt;
    [SerializeField] Text killCount_Txt;
    [SerializeField] Text coinCount_Txt;

    private List<Text> data_texts = new List<Text>();

    private void Start()
    {
        panelEndLevel.SetActive(false);

    }
    private void ResultStatus(string status)    // status is win or lose
    {
        if (status.ToLower() == "win")
        {
            Debug.Log("Win");
        }
        else if (status.ToLower() == "lose")
        {
            circleBack.GetComponent<Image>().sprite = loseCircle;
            playerInCircle.GetComponent<Image>().sprite = losePlayerInCircle;
        }
        
        StartCoroutine(ShowPanelStatistic());

    }
    IEnumerator ShowPanelStatistic() // For show Status win or lose Panel
    {
        foreach (var item in data_texts)
        {
            item.transform.localScale = Vector3.zero;
        }

        panelEndLevel.SetActive(true);
        panelEndLevel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0f, 3000, 0f);
        panelEndLevel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, 0f), 1f, false).SetEase(Ease.InSine);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(StatisticAnimetion());
    }
    IEnumerator StatisticAnimetion()
    {
        
        foreach (var item in data_texts)
        {
            item.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
        Time.timeScale = 0;
    }
    private void SetStatistic(string timeFinished, int killCount, int coinCount)
    {
        levelName_Txt.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();
        timeFinished_Txt.text = timeFinished;
        killCount_Txt.text = killCount.ToString();
        coinCount_Txt.text = coinCount.ToString();
        data_texts = new List<Text>() { levelName_Txt, timeFinished_Txt, killCount_Txt, coinCount_Txt };
    }

    public void GameFinish(string status, string timeFinished, int killCount, int coinCount)// status is "win" or "lose", timeFinished format: "3:45" kills, coins 
    {
        SetStatistic(timeFinished, killCount, coinCount);
        ResultStatus(status);
    } 

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartLevel()
    {
        if (GameData.Energy >= 15)
        {
            GameData.Energy -= 15;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else EnergyPanel.GetBuyEnergyPanel();
    }
}
