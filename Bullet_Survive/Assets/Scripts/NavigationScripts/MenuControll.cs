using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

enum StatusMenu
{
    inShop,
    inHome,
    inThird,
    inFour
}
public class MenuControll : MonoBehaviour
{
    public SwipeLevels swipeLevels;
    [SerializeField] private GameObject ContentWithLevels; //for find child image

    [SerializeField] private GameObject animatorLoadScene;
    [SerializeField] private GameObject shop_UI;
    [SerializeField] private GameObject home_UI;
    [SerializeField] private GameObject energy_UI;
    [SerializeField] private GameObject selectedLevel_UI;

    [Header("ButtonsMenu")]
    [SerializeField] private Button shop_btn;
    [SerializeField] private Button home_btn;
    [SerializeField] private Button third_btn;
    [SerializeField] private Button four_btn;
    [SerializeField] private Button start_btn;
    [SerializeField] private Button iconLevel_btn;
    [SerializeField] private Button selectLevel_btn;
    [SerializeField] private Button closeSelected_UI_btn;

    [Header("Particles")]
    [SerializeField] private ParticleSystem gold_prtc;
    [SerializeField] private ParticleSystem crystal_prtc;

    [Header("sprites from icon button")]
    [SerializeField] private GameObject homeIcon;
    [SerializeField] private GameObject shopIcon;
    [SerializeField] private GameObject thirdIcon;
    [SerializeField] private GameObject fourIcon;
    [SerializeField] private Sprite backgroundActiveBtn;
    [SerializeField] private Sprite bacgroundDefaultBtn;

    private StatusMenu currentStatus = StatusMenu.inHome;

    private void LoadLevel()
    {
        animatorLoadScene.SetActive(true);
        StartCoroutine(LoadLevelCourotine());
    }
    IEnumerator LoadLevelCourotine()
    {
        animatorLoadScene.GetComponent<Animator>().SetTrigger("OpenLoadTrigger");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(1);
    }
    public void PlayParticle_Crystal()
    {
        crystal_prtc.gameObject.SetActive(true);
        crystal_prtc.Play();
    }
    private void Awake()
    {
        currentStatus = StatusMenu.inHome;
        updateStatusMenu();
    }
    private void Start()
    {
        #region [ Button Settings ]

        selectLevel_btn.onClick.RemoveAllListeners();
        selectLevel_btn.onClick.AddListener(SelectLevel);

        closeSelected_UI_btn.onClick.RemoveAllListeners();
        closeSelected_UI_btn.onClick.AddListener(CloseLevelSelect);

        iconLevel_btn.onClick.RemoveAllListeners();
        iconLevel_btn.onClick.AddListener(OpenSelectedLevels);

        shop_btn.onClick.RemoveAllListeners();
        shop_btn.onClick.AddListener(delegate { currentStatus = StatusMenu.inShop; });
        shop_btn.onClick.AddListener(updateStatusMenu);

        home_btn.onClick.RemoveAllListeners();
        home_btn.onClick.AddListener(delegate { currentStatus = StatusMenu.inHome; });
        home_btn.onClick.AddListener(updateStatusMenu);

        third_btn.onClick.RemoveAllListeners();
        third_btn.onClick.AddListener(delegate { currentStatus = StatusMenu.inThird; });
        third_btn.onClick.AddListener(updateStatusMenu);

        four_btn.onClick.RemoveAllListeners();
        four_btn.onClick.AddListener(delegate { currentStatus = StatusMenu.inFour; });
        four_btn.onClick.AddListener(updateStatusMenu);

        start_btn.onClick.RemoveAllListeners();
        start_btn.onClick.AddListener(LoadLevel);
        #endregion
    }
    private void AnimationButtonIcon(GameObject icon_btn) //single animation for multyply buttons
    {
        DG.Tweening.Sequence mySequence = DOTween.Sequence();
        mySequence.Append(icon_btn.transform.DOScale(1.2f, 0.2f));
        mySequence.Append(icon_btn.transform.DORotate(new Vector3(0f, 0f, -10f), 0.2f));
        mySequence.Append(icon_btn.transform.DORotate(new Vector3(0f, 0f, 0f), 0.2f));
        mySequence.Append(icon_btn.transform.DORotate(new Vector3(0f, 0f, 10f), 0.2f));
        mySequence.Append(icon_btn.transform.DORotate(new Vector3(0f, 0f, 0f), 0.2f));
        mySequence.Append(icon_btn.transform.DOScale(1f, 0.2f));
        mySequence.Play();
    }
    private void updateStatusMenu()
    {
        shop_btn.GetComponent<Image>().sprite = bacgroundDefaultBtn;
        home_btn.GetComponent<Image>().sprite = bacgroundDefaultBtn;
        third_btn.GetComponent<Image>().sprite = bacgroundDefaultBtn;
        four_btn.GetComponent<Image>().sprite = bacgroundDefaultBtn;
        shop_UI.SetActive(false);
        switch (currentStatus)
        {
            case StatusMenu.inHome: //if press button home
                home_btn.GetComponent<Image>().sprite = backgroundActiveBtn;
                AnimationButtonIcon(homeIcon);
                Debug.Log("hi");
                break;

            case StatusMenu.inShop: //if press button shop
                shop_btn.GetComponent<Image>().sprite = backgroundActiveBtn;
                shop_UI.SetActive(true);
                AnimationButtonIcon(shopIcon);
                Debug.Log("hi2");
                break;
            case StatusMenu.inThird: //if press button shop
                third_btn.GetComponent<Image>().sprite = backgroundActiveBtn;
                //shop_UI.SetActive(true);
                AnimationButtonIcon(thirdIcon);
                Debug.Log("hi2");
                break;
            case StatusMenu.inFour: //if press button shop
                four_btn.GetComponent<Image>().sprite = backgroundActiveBtn;
                //shop_UI.SetActive(true);
                AnimationButtonIcon(fourIcon);
                Debug.Log("hi2");
                break;

        }

    }
    private void OpenSelectedLevels()
    {
        selectedLevel_UI.SetActive(true);
    }
    private void CloseLevelSelect()
    {
        selectedLevel_UI.SetActive(false);
    }
    private void SelectLevel()
    {
        swipeLevels.GetSelectedLevel();
        int currentLevelNumber = GameData.CurrentLevel;
        iconLevel_btn.GetComponent<Image>().sprite = ContentWithLevels.transform.GetChild(currentLevelNumber).GetComponent<Image>().sprite;
        selectedLevel_UI.SetActive(false);
    }
}
