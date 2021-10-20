using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectMultiplier : MonoBehaviour
{
    public bool isDestroyer;
    public bool subtract;


    public int objectMultiplierDisplay = 2;
    public int objectMultiplier = 2;

    public GameObject[] objectPrefab;
    public GameObject[] peeledPrefab;
    public GameObject[] friesPrefab;
    public GameObject[] fryerPrefab;

    public Transform objectSpawnPont;
    public float m_Thrust;
    private int randomPrefabs;
    //public Transform objectParent;
    bool single;

    public TextMeshPro multiplyText;

    public enum muliplierParentChanger { normalPotato, PeeledPotato, fires, fryingfries }
    public muliplierParentChanger parentChanger;
    public MultiplierMovement mm;


    //Potatoe multiplier count is high for record mode
    bool isRecordMode = false;




    public void Start()
    {
        if (!isRecordMode)
            objectMultiplier = objectMultiplierDisplay;
    }
    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void OnValidate()
    {
        if (multiplyText != null)
        {
            multiplyText.text = "x" + objectMultiplierDisplay;
        }
        if (subtract)
        {
            multiplyText.text = "-" + objectMultiplierDisplay;
        }
    }

    void SpawnObjects(int num)
    {
        switch (parentChanger)
        {
            case muliplierParentChanger.normalPotato:
                for (int i = 0; i < num; i++)
                {
                    randomPrefabs = Random.Range(0, 6);
                    GameObject objectSpawn = Instantiate(objectPrefab[randomPrefabs], GameManager.Instance.startingTrackerSpawnner.position,
                        Quaternion.identity);
                    objectSpawn.transform.position = GameManager.Instance.startingTrackerSpawnner.position;
                    objectSpawn.transform.SetParent(GameManager.Instance.objectParent);
                    PotatoresTrack.Instance.PotatoesCount();
                }
                break;
            case muliplierParentChanger.PeeledPotato:
                for (int i = 0; i < num; i++)
                {
                    randomPrefabs = Random.Range(0, 6);
                    GameObject peeledSpawn = Instantiate(peeledPrefab[randomPrefabs], GameManager.Instance.PeeledTrackerSpawnner.position,
                        Quaternion.identity);
                    peeledSpawn.transform.position = GameManager.Instance.PeeledTrackerSpawnner.position;
                    peeledSpawn.transform.SetParent(GameManager.Instance.peeledParent);
                    PeeledPotatoCount.Instance.PeeledPotatoesCount();
                }
                break;
            case muliplierParentChanger.fires:
                for (int i = 0; i < num; i++)
                {
                    randomPrefabs = Random.Range(0, 6);
                    GameObject peeledSpawn = Instantiate(friesPrefab[randomPrefabs], GameManager.Instance.FriesTrackerSpawnner.position,
                        Quaternion.identity);
                    peeledSpawn.transform.position = GameManager.Instance.FriesTrackerSpawnner.position;
                    peeledSpawn.transform.SetParent(GameManager.Instance.friesParent);
                    FriesCount.Instance.friesPotatoesCount();
                }
                break;
            case muliplierParentChanger.fryingfries:
                for (int i = 0; i < num; i++)
                {
                    randomPrefabs = Random.Range(0, 6);
                    GameObject peeledSpawn = Instantiate(fryerPrefab[randomPrefabs], GameManager.Instance.FriesFryerTrackerSpawnner.position,
                        Quaternion.identity);
                    peeledSpawn.transform.position = GameManager.Instance.FriesFryerTrackerSpawnner.position;
                    peeledSpawn.transform.SetParent(GameManager.Instance.FriesFryerParent);
                    FriesFryingCount.Instance.friesFryingPotatoesCount();
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Potato") && !single)
        {
            if (isDestroyer)
            {
                PlaySFX(false);
                DestoryObs(objectMultiplier);
                Destroy(gameObject.transform.parent.gameObject.transform.gameObject);
            }
            else
            {
                PlaySFX(true);
                SpawnObjects(objectMultiplier);
                PotatoresTrack.Instance.PotatoesCount();
                Destroy(gameObject.transform.parent.gameObject.transform.gameObject);

            }
            mm.stopTween();
            //PotatoresTrack.Instance.PotatoesCount();
            single = true;
        }
        if (other.gameObject.CompareTag("PotatoPeeled") && !single)
        {
            if (isDestroyer)
            {
                PlaySFX(false);
                DestoryPeeled(objectMultiplier);
                Destroy(gameObject.transform.parent.gameObject.transform.gameObject);

            }
            else
            {
                PlaySFX(true);
                SpawnObjects(objectMultiplier);
                PeeledPotatoCount.Instance.PeeledPotatoesCount();
                Destroy(gameObject.transform.parent.gameObject.transform.gameObject);
            }
            mm.stopTween();
            //PeeledPotatoCount.Instance.PeeledPotatoesCount();
            single = true;
        }

        if (other.gameObject.CompareTag("Fries") && !single)
        {
            if (isDestroyer)
            {
                PlaySFX(false);
                DestoryFries(objectMultiplier);
                Destroy(gameObject.transform.parent.gameObject.transform.gameObject);

            }
            else
            {
                PlaySFX(true);
                SpawnObjects(objectMultiplier);
                FriesCount.Instance.friesPotatoesCount();
                Destroy(gameObject.transform.parent.gameObject.transform.gameObject);
            }
            mm.stopTween();
            //PeeledPotatoCount.Instance.PeeledPotatoesCount();
            single = true;
        }
        if (other.gameObject.CompareTag("FriedFries") && !single)
        {
            if (isDestroyer)
            {
                PlaySFX(false);
                DestoryFriedFries(objectMultiplier);
                Destroy(gameObject.transform.parent.gameObject.transform.gameObject);

            }
            else
            {
                PlaySFX(true);

                SpawnObjects(objectMultiplier);
                FriesFryingCount.Instance.friesFryingPotatoesCount();
                Destroy(gameObject.transform.parent.gameObject.transform.gameObject);
            }
            mm.stopTween();
            //PeeledPotatoCount.Instance.PeeledPotatoesCount();
            single = true;
        }
    }

    public void DestoryObs(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Destroy(PotatoresTrack.Instance.PotatoesParent.GetChild(i).gameObject);
            PotatoresTrack.Instance.potatoeLessCount();
        }
    }
    public void DestoryPeeled(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Destroy(PeeledPotatoCount.Instance.PotatoesParent.GetChild(i).gameObject);
            PeeledPotatoCount.Instance.PelledpotatoeLessCount();
        }
    }

    public void DestoryFries(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Destroy(FriesCount.Instance.FriesParent.GetChild(i).gameObject);
            FriesCount.Instance.friesLessCount();
        }
    }
    public void DestoryFriedFries(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Destroy(FriesFryingCount.Instance.FriesFryingParent.GetChild(i).gameObject);
            FriesFryingCount.Instance.friesFryingLessCount();
        }
    }


    void PlaySFX(bool state)
    {
        if (state)
            AudioManager.instance.PlaySFX(AudioManager.instance.collectablePositive);
        else
            AudioManager.instance.PlaySFX(AudioManager.instance.collectableNegative);


    }
}
