using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeledPotatoCount : MonoBehaviour
{
    #region Singleton
    public static PeeledPotatoCount Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public Transform PotatoesParent;
    public int peeledPotatoesStart;
    public int peeledPotatoesCount;
    // Start is called before the first frame update
    void Start()
    {
        PeeledPotatoesCount();
    }

    public void PeeledPotatoesCount()
    {
        peeledPotatoesStart = PotatoesParent.childCount;
    }
    public void PelledpotatoeLessCount()
    {
        StartCoroutine(checkDestroy());
    }
    IEnumerator checkDestroy()
    {
        yield return new WaitForSeconds(0.02f);
        peeledPotatoesStart = PotatoesParent.childCount;
        if (peeledPotatoesStart == 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
