using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriesCount : MonoBehaviour
{
    #region Singleton
    public static FriesCount Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public Transform FriesParent;
    public int friesStart;
    public int friesCount;
    // Start is called before the first frame update
    void Start()
    {
        friesPotatoesCount();
    }

    public void friesPotatoesCount()
    {
        friesStart = FriesParent.childCount;
    }
    public void friesLessCount()
    {
        StartCoroutine(checkDestroy());
    }
    IEnumerator checkDestroy()
    {
        yield return new WaitForSeconds(0.02f);
        friesStart = FriesParent.childCount;
        if (friesStart == 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
