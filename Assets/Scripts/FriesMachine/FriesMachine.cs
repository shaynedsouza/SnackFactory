using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FriesMachine : MonoBehaviour
{
    #region Singleton
    public static FriesMachine Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public GameObject[] blades;
    public GameObject[] friesPrefabs;
    private int randomPrefabs;
    public float m_Thrust;
    //public Collider _collider;
    public GameObject friesMachine;

    public GameObject spawnEffect;
    public Transform friesParent;
    public ParticleSystem ps1, ps2; //ps1 is wood particles(potato skin)   ps2 is smoke ps
    public int countSpawned;


    public List<GameObject> potatoes;
    int lastPotato = 0;



    // Start is called before the first frame update
    private void Start()
    {
        //_collider = GetComponentInChildren<Collider>();

    }

    public void StartSpawn(int num)
    {
        StartCoroutine(SpawnFries(num));
        AudioManager.instance.PlaySFX(AudioManager.instance.cutPotatoes);

    }

    public IEnumerator SpawnFries(int num)
    {
        // ps1.Play();
        ps2.Play();
        for (int i = 0; i < blades.Length; i++)
        {
            blades[i].transform.DOLocalMoveY(0.35f, 0.1f).SetLoops(-1, LoopType.Yoyo).SetDelay((i + 1) % 2 == 0 ? 0f : 0.5f);
        }
        foreach (GameObject child in potatoes)
        {
            child.transform.DOLocalMoveY(0.4f, 0.4f).SetLoops(Random.Range(3, 4), LoopType.Yoyo).SetDelay(Random.Range(0f, 0.7f)).OnComplete(() => child.SetActive(false));
        }


        for (int i = 0; i < num; i++)
        {

            countSpawned++;

            randomPrefabs = Random.Range(0, 6);

            GameObject fires = Instantiate(friesPrefabs[randomPrefabs],
                transform.position, Quaternion.identity);
            fires.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * m_Thrust, ForceMode.Impulse);
            fires.transform.SetParent(friesParent);
            friesMachine.transform.DORewind();
            friesMachine.transform.DOPunchScale(Vector3.one / 5, .3f, 10, 1);

            // GameObject effectSpawn = Instantiate(spawnEffect, transform.position, transform.rotation);
            // Destroy(effectSpawn, 0.2f);
            FriesCount.Instance.friesPotatoesCount();

            // yield return new WaitForSeconds(0.05f);

            //Process should take 1.5 secs 
            yield return new WaitForSeconds(1.5f / num);
        }

        if (countSpawned >= PeeledPotatoCount.Instance.peeledPotatoesCount)
        {

            for (int i = 0; i < blades.Length; i++)
            {
                blades[i].transform.DOLocalMoveY(0.35f, 0.1f).SetLoops(-1, LoopType.Yoyo).SetDelay((i + 1) % 2 == 0 ? 0f : 0.5f);
            }

            foreach (GameObject child in blades)
            {
                DOTween.Kill(child.transform);
                child.transform.DOLocalMoveY(0.035f, 0.2f);
            }
            //FindObjectOfType<PeelingEffect>().peelingEffect.Stop();
            //FindObjectOfType<PeelingEffect>().smoke.Stop();
            AudioManager.instance.StopSFX();
            GameManager.Instance.ChangeCameraToFriesFollow();

        }
    }


    public void PotatoEncountered()
    {
        if (lastPotato < potatoes.Count)
        {
            potatoes[lastPotato].SetActive(true);
            lastPotato++;
        }
    }



}
