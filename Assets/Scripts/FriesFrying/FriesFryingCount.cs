using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FriesFryingCount : MonoBehaviour
{
    #region Singleton
    public static FriesFryingCount Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public Transform FriesFryingParent;
    public int friesFryingStart;
    public int friesFryingCount;
    public bool isFinalScene = false;


    void Start()
    {
        friesFryingPotatoesCount();
    }
    private void Update()
    {
        if (isFinalScene)
        {
            if (FriesFryingParent.childCount <= 3)
            {
                //Avoid calling multiple times
                isFinalScene = false;
                GameManager.Instance.GameWon();
            }
        }
    }


    public void friesFryingPotatoesCount()
    {
        friesFryingStart = FriesFryingParent.childCount;
    }
    public void friesFryingLessCount()
    {
        StartCoroutine(checkDestroy());
    }
    IEnumerator checkDestroy()
    {
        yield return new WaitForSeconds(0.02f);
        friesFryingStart = FriesFryingParent.childCount;
        if (friesFryingStart == 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
