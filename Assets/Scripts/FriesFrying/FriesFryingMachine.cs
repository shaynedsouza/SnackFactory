using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FriesFryingMachine : MonoBehaviour
{
    #region Singleton
    public static FriesFryingMachine Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public GameObject[] friesPrefabs;
    private int randomPrefabs;
    public float m_Thrust;
    //public Collider _collider;
    public GameObject friesFryingMachine;

    public GameObject spawnEffect;
    public Transform friesFryingParent;

    public int countSpawned;

    public GameObject basket;
    public List<GameObject> friesInBasket;
    public ParticleSystem steamPS;


    int lastFry = 0;

    // Start is called before the first frame update
    private void Start()
    {
        //_collider = GetComponentInChildren<Collider>();
    }



    public void ActivateFry()
    {
        if (lastFry < friesInBasket.Count)
        {
            friesInBasket[lastFry].SetActive(true);
            lastFry++;
        }
    }



    public void StartCook(int count)
    {
        steamPS.Play();
        AudioManager.instance.PlaySFX(AudioManager.instance.fryPotatoes, 0.7f);

        // basket.transform.DOLocalMoveY(1f, 0.5f).SetLoops(4, LoopType.Yoyo).OnComplete(() =>
        basket.transform.DOLocalMoveY(1f, 0.5f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            basket.transform.DOLocalMoveY(1f, 0.5f).SetLoops(2, LoopType.Yoyo).SetDelay(1f).OnComplete(() =>
            {
                basket.transform.DOLocalMoveY(0.8f, 0.3f).SetDelay(1f).OnComplete(() =>
                       {
                           basket.transform.DOLocalRotate(new Vector3(basket.transform.eulerAngles.x, basket.transform.eulerAngles.y, 25f), 0.5f).OnComplete(() =>
                           {
                               StartCoroutine(SpawnFries(count));
                           });

                       });
            });
        });
    }

    public void StartSpawn(int num)
    {
        StartCoroutine(SpawnFries(num));
    }
    public IEnumerator SpawnFries(int num)
    {
        AudioManager.instance.StopSFX();
        for (int i = 0; i < num; i++)
        {

            if (i < friesInBasket.Count)
            {
                friesInBasket[friesInBasket.Count - i - 1].SetActive(false);
            }



            countSpawned++;
            randomPrefabs = Random.Range(0, 6);

            GameObject fires = Instantiate(friesPrefabs[randomPrefabs],
                transform.position, Quaternion.identity);
            fires.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * m_Thrust, ForceMode.Impulse);
            fires.transform.SetParent(friesFryingParent);
            friesFryingMachine.transform.DORewind();
            friesFryingMachine.transform.DOPunchScale(Vector3.one / 10, .3f, 10, 1);

            GameObject effectSpawn = Instantiate(spawnEffect, transform.position, transform.rotation);
            Destroy(effectSpawn, 0.2f);
            FriesFryingCount.Instance.friesFryingPotatoesCount();
            // yield return new WaitForSeconds(0.05f);


            //Process should take 1.5 secs 
            yield return new WaitForSeconds(1.5f / num);
        }

        if (countSpawned >= FriesCount.Instance.friesCount)
        {
            //FindObjectOfType<PeelingEffect>().peelingEffect.Stop();
            //FindObjectOfType<PeelingEffect>().smoke.Stop();
            GameManager.Instance.ChangeCameraToFriesFryingFollow();

        }
    }
}
