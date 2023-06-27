using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPCore : MonoBehaviour, IStoreListener
{
    //[SerializeField] private GameObject panelAds;
    private int crystal;
    private static IStoreController m_StoreController;          // доступ до системи Unity Purchasing
    private static IExtensionProvider m_StoreExtensionProvider; // підсистема для покупок для конкретних магазинів

    public static string noADS = "no_ads"; //одноразова - nonconsumable
    public static string crystal_250 = "crystal_250"; //багаторозова - consumable
    public static string crystal_600 = "crystal_600"; //багаторозова - consumable
    public static string crystal_1000 = "crystal_1000"; //багаторозова - consumable
    public static string crystal_2000 = "crystal_2000"; //багаторозова - consumable
    public static string crystal_5000 = "crystal_5000"; //багаторозова - consumable
    public static string crystal_15000 = "crystal_15000"; //багаторозова - consumable

    void Start()
    {
        if (m_StoreController == null) // ініціалізація покупок
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized()) //якщо уже підключені до системи то виходимо
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Добавляємо всі товари в білдер
        builder.AddProduct(noADS, ProductType.NonConsumable);
        builder.AddProduct(crystal_250, ProductType.Consumable);
        builder.AddProduct(crystal_600, ProductType.Consumable);
        builder.AddProduct(crystal_1000, ProductType.Consumable);
        builder.AddProduct(crystal_2000, ProductType.Consumable);
        builder.AddProduct(crystal_5000, ProductType.Consumable);
        builder.AddProduct(crystal_15000, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void Buy_noads()
    {
        BuyProductID(noADS);
    }

    public void Buy_Crystal_250()
    {
        BuyProductID(crystal_250);
    }
    public void Buy_Crystal_600()
    {
        BuyProductID(crystal_600);
    }
    public void Buy_Crystal_1000()
    {
        BuyProductID(crystal_1000);
    }
    public void Buy_Crystal_2000()
    {
        BuyProductID(crystal_2000);
    }
    public void Buy_Crystal_5000()
    {
        BuyProductID(crystal_5000);
    }
    public void Buy_Crystal_15000()
    {
        BuyProductID(crystal_15000);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized()) //провірка чи покупка ініціалізувалась
        {
            Product product = m_StoreController.products.WithID(productId); //знаходимо продукт покупки 

            if (product != null && product.availableToPurchase) //Якщо продукт знайдений та готовий для покупки
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product); //купити
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) //контроль покупок
    {
        if (String.Equals(args.purchasedProduct.definition.id, noADS, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));

            //дії при покупці
            if (PlayerPrefs.HasKey("NoADSisBuy") == false) // відключити рекламу
            {
                PlayerPrefs.SetInt("NoADSisBuy", 0);          
            }

        }
        else if (String.Equals(args.purchasedProduct.definition.id, crystal_250, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //дії при покупці
            crystal = GameData.Crystal;
            crystal += 250;
            GameData.Crystal = crystal;
            if (CurrencyControll.instance != null)
                CurrencyControll.instance.UpdateTextUI();
            if (MenuControll.instance != null)
                MenuControll.instance.PlayParticle_Crystal();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, crystal_600, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //дії при покупці
            crystal = GameData.Crystal;
            crystal += 600;
            GameData.Crystal = crystal;
            if (CurrencyControll.instance != null)
                CurrencyControll.instance.UpdateTextUI();
            if (MenuControll.instance != null)
                MenuControll.instance.PlayParticle_Crystal();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, crystal_1000, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //дії при покупці
            crystal = GameData.Crystal;
            crystal += 1000;
            GameData.Crystal = crystal;
            if (CurrencyControll.instance != null)
                CurrencyControll.instance.UpdateTextUI();
            if (MenuControll.instance != null)
                MenuControll.instance.PlayParticle_Crystal();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, crystal_2000, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //дії при покупці
            crystal = GameData.Crystal;
            crystal += 2000;
            GameData.Crystal = crystal;
            if (CurrencyControll.instance != null)
                CurrencyControll.instance.UpdateTextUI();
            if (MenuControll.instance != null)
                MenuControll.instance.PlayParticle_Crystal();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, crystal_5000, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //дії при покупці
            crystal = GameData.Crystal;
            crystal += 5000;
            GameData.Crystal = crystal;
            if (CurrencyControll.instance != null)
                CurrencyControll.instance.UpdateTextUI();
            if (MenuControll.instance != null)
                MenuControll.instance.PlayParticle_Crystal();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, crystal_15000, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            //дії при покупці
            crystal = GameData.Crystal;
            crystal += 15000;
            GameData.Crystal = crystal;
            if (CurrencyControll.instance != null)
                CurrencyControll.instance.UpdateTextUI();
            if (MenuControll.instance != null)
                MenuControll.instance.PlayParticle_Crystal();
        }

        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        return PurchaseProcessingResult.Complete;
    }

    public void RestorePurchases() //Відновлюємо покупки (потрібно тільки для Apple).
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer) //если запущенно на эпл устройстве
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();

            apple.RestoreTransactions((result) =>
            {
                Debug.Log("RestorePurchases continuing: " + result +
                    ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }
    public void OnInitializeFailed(InitializationFailureReason error, string str)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }



}
