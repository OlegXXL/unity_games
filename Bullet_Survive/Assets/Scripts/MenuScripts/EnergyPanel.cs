using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public static class EnergyPanel
{
    //public static GameObject buyEnergyPanelPrefab;
    public static void GetBuyEnergyPanel()
    {
        GameObject canvasObject = GameObject.Find("Canvas");
        if (canvasObject == null)
        {
            Debug.LogError("Canvas not found in scene!");
            return;
        }
        else
        {
            Debug.Log("compite create next initializate");
            GameObject panel = GameObject.Instantiate(Resources.Load<GameObject>("BuyEnergyPanel"), canvasObject.transform);
            Debug.Log("compite 2");
            Button buyByDiamonds_Btn = GameObject.Find("BuyByDiamonds").GetComponent<Button>();
            Button BuyByADS_Btn = GameObject.Find("BuyByADS").GetComponent<Button>();
            Button closePanelBtn = panel.GetComponent<Button>();

            closePanelBtn.onClick.AddListener(() =>
            {
                GameObject.Destroy(panel);
            });

            buyByDiamonds_Btn.onClick.AddListener(() =>
            {
                if (GameData.Crystal >= 80)
                {
                    GameData.Crystal -= 80;
                    GameData.Energy += 30;
                    GameData.UpdateDataText();
                    if (panel != null)
                    {
                        GameObject.Destroy(panel);
                    }
                }
            });
            BuyByADS_Btn.onClick.AddListener(() =>
            {
                if (GameData.Crystal >= 80)
                {
                    GameData.Crystal -= 80;
                    GameData.Energy += 15;
                    GameData.UpdateDataText();
                    if (panel != null)
                    {
                        GameObject.Destroy(panel);
                    }
                }
            });
        }
        
    }
}
