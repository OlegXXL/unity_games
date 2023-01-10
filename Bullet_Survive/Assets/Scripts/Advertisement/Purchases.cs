using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchases : MonoBehaviour
{
    public CurrencyControll currencyControll;
    public MenuControll menuControll;
    public void OnPurchaseCompleted(Product product)
    {
        switch (product.definition.id)
        {
            case "com.ora.survive_imp.crystal250":
                AddCrystal_250();
                break;
            case "com.ora.survive_imp.crystal600":
                AddCrystal_600();
                break;
            case "com.ora.survive_imp.crystal1000":
                AddCrystal_1000();
                break;
            case "com.ora.survive_imp.crystal2000":
                AddCrystal_2000();
                break;
            case "com.ora.survive_imp.crystal5000":
                AddCrystal_5000();
                break;
            case "com.ora.survive_imp.crystal10000":
                AddCrystal_10000();
                break;
        }
    }
    private void AddCrystal_250()
    {
        GameData.Crystal += 250;
        currencyControll.UpdateTextUI();
        menuControll.PlayParticle_Crystal();
    }
    private void AddCrystal_600()
    {
        GameData.Crystal += 600;
        currencyControll.UpdateTextUI();
        menuControll.PlayParticle_Crystal();
    }
    private void AddCrystal_1000()
    {
        GameData.Crystal += 1000;
        currencyControll.UpdateTextUI();
        menuControll.PlayParticle_Crystal();
    }
    private void AddCrystal_2000()
    {
        GameData.Crystal += 2000;
        currencyControll.UpdateTextUI();
        menuControll.PlayParticle_Crystal();
    }
    private void AddCrystal_5000()
    {
        GameData.Crystal += 5000;
        currencyControll.UpdateTextUI();
        menuControll.PlayParticle_Crystal();
    }
    private void AddCrystal_10000()
    {
        GameData.Crystal += 10000;
        menuControll.PlayParticle_Crystal();
        currencyControll.UpdateTextUI();
    }
}
