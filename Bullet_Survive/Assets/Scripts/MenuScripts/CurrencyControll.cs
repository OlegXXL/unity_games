using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyControll : MonoBehaviour
{
    public static CurrencyControll instance;

    [SerializeField] private Text currentGold_txt;
    [SerializeField] private Text currentCrystal_txt;
    private int currentGold;
    private int currentCrystal;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void UpdateTextUI() //update text (gold, crystal)
    {
        currentGold_txt.text = GameData.Gold.ToString();
        currentCrystal_txt.text = GameData.Crystal.ToString();
    }

    private void Awake()
    {
        UpdateTextUI();
    }

}
