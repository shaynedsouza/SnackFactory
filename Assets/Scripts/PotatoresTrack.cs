using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoresTrack : MonoBehaviour
{
    #region Singleton
    public static PotatoresTrack Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion


    public Transform PotatoesParent;
    public int startingTotalPotatoes;
    public int potatoesCounter;
    // Start is called before the first frame update
    void Start()
    {
        PotatoesCount();
    }

    public void PotatoesCount()
    {
        startingTotalPotatoes = PotatoesParent.childCount;
    }

    public void potatoeLessCount()
    {
        StartCoroutine(checkDestroy());
    }
    IEnumerator checkDestroy()
    {
        yield return new WaitForSeconds(0.05f);
        startingTotalPotatoes = PotatoesParent.childCount;
        if (startingTotalPotatoes == 0)
        {
            GameManager.Instance.GameOver();
        }
    }

}
