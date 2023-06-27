using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControll : MonoBehaviour
{
    //[SerializeField] List<GameObject> coin_btns = new List<GameObject>();
    public CurrencyControll currencyControll;
    public MenuControll menuControll;


    /*private int count_coins;
    private int price_coins;
    void Start()
    {
        foreach (GameObject btn_coin in coin_btns)
        {
            btn_coin.GetComponent<Button>().onClick.RemoveAllListeners();
            for (int i = 0; i < btn_coin.transform.childCount; i++)
            {
                if (btn_coin.transform.GetChild(i).transform.name == "Count")
                {
                    count_coins = Int32.Parse(btn_coin.transform.GetChild(i).GetComponent<Text>().text.ToString().Replace(" ", ""));
                }
                else if (btn_coin.transform.GetChild(i).transform.name == "Price")
                {
                    price_coins = Int32.Parse(btn_coin.transform.GetChild(i).GetComponent<Text>().text.ToString().Replace(" ", ""));
                }
            }
            Debug.Log(count_coins);
            btn_coin.GetComponent<Button>().onClick.AddListener(() => BuyCoins(price_coins));
        }
    }*/

    public void BuyCoins(int price)
    {
        int count = price * 10;
        int current_crystal = GameData.Crystal;
        if (price <= current_crystal)
        {
            GameData.Crystal -= price;
            GameData.Gold += count;
            currencyControll.UpdateTextUI();
            menuControll.PlayParticle_Coins();
        }
    }
}
