using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour
{
    public GameObject awesome, badJob;
    public Image continueBtn, retryBtn;
    public TextMeshProUGUI levelText;
    public static CanvasManager Instance;
    bool doOnce = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }




    public void SetLevel(int levelNo)
    {
        if (levelNo < 10)
            levelText.text = "Level 0" + levelNo.ToString();
        else
            levelText.text = "Level " + levelNo.ToString();
    }


    public void GameWon()
    {
        if (doOnce)
        {
            awesome.transform.localScale = Vector3.zero;
            awesome.SetActive(true);
            awesome.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);

            Vector2 targetPos = continueBtn.rectTransform.anchoredPosition;
            continueBtn.rectTransform.anchoredPosition = targetPos + Vector2.down * 800f;
            continueBtn.gameObject.SetActive(true);
            continueBtn.rectTransform.DOAnchorPos(targetPos, 1.5f).SetDelay(0.8f);
        }
    }


    public void GameLost()
    {
        if (doOnce)
        {
            doOnce = false;
            badJob.transform.localScale = Vector3.zero;
            badJob.SetActive(true);
            badJob.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutSine);

            Vector2 targetPos = retryBtn.rectTransform.anchoredPosition;
            retryBtn.rectTransform.anchoredPosition = targetPos + Vector2.down * 800f;
            retryBtn.gameObject.SetActive(true);
            retryBtn.rectTransform.DOAnchorPos(targetPos, 1.5f).SetDelay(0.8f);
        }
    }
}
