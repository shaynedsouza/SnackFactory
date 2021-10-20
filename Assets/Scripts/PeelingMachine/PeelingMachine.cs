using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PeelingMachine : MonoBehaviour
{
    public GameObject[] potatosPrefabs;
    private int randomPrefabs;
    public float m_Thrust;
    //public Collider _collider;
    public GameObject peelingMachine;

    public GameObject spawnEffect;
    public Transform peeledParent;

    public int countSpawned;
    // Start is called before the first frame update
    private void Start()
    {
        //_collider = GetComponentInChildren<Collider>();
    }

    public void StartSpawn(int num)
    {
        StartCoroutine(SpawnPotatoas(num));
    }

    public IEnumerator SpawnPotatoas(int num)
    {
        for (int i = 0; i < num; i++)
        {
            countSpawned++;
            randomPrefabs = Random.Range(0, 6);

            GameObject potatos = Instantiate(potatosPrefabs[randomPrefabs],
                transform.position, Quaternion.identity);
            potatos.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * m_Thrust, ForceMode.Impulse);
            potatos.transform.SetParent(peeledParent);
            peelingMachine.transform.DORewind();
            peelingMachine.transform.DOPunchScale(Vector3.one / 15, .3f, 10, 1);

            GameObject effectSpawn = Instantiate(spawnEffect, transform.position, transform.rotation);
            Destroy(effectSpawn, 2f);
            PeeledPotatoCount.Instance.PeeledPotatoesCount();
            //yield return new WaitForSeconds(0.08f);

            //Process should take 1.5 secs 
            yield return new WaitForSeconds(1.5f / num);

        }

        if (countSpawned == PotatoresTrack.Instance.potatoesCounter)
        {
            //ConveyorBelt.Instance.startMove = false;

            FindObjectOfType<PeelingEffect>().peelingEffect.Stop();
            FindObjectOfType<PeelingEffect>().smoke.Stop();
            AudioManager.instance.StopSFX();
            GameManager.Instance.ChangeCameraToPeelingFollow();

        }
    }
    //private Vector3 RandomPointInBox()
    //{
    //    return _collider.bounds.center + new Vector3(
    //       (Random.value - 0.1f) * _collider.bounds.size.x,
    //       (Random.value - 0.1f) * _collider.bounds.size.y,
    //       0
    //    );
    //}
}
