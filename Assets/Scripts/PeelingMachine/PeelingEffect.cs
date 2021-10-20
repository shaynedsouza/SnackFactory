using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PeelingEffect : MonoBehaviour
{
    public GameObject blade;
    public GameObject peelingMachine;

    public ParticleSystem peelingEffect, smoke;
    public float rotatingSpeed;
    bool startRot;
    private void Update()
    {
        if (startRot)
        {
            blade.transform.Rotate(new Vector3(0f, 0f, 180f) * Time.deltaTime * rotatingSpeed);
        }

    }

    public IEnumerator StartPeeling()
    {
        yield return new WaitForSeconds(0.1f);
        smoke.Play();
        peelingEffect.Play();
        startRot = true;
        //blade.transform.DORotate(new Vector3(0, 0, 180), 1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        StartCoroutine(startSpawnPeelingMachine());
        AudioManager.instance.PlaySFX(AudioManager.instance.peelPotatoes, 0.7f);
    }

    public IEnumerator startSpawnPeelingMachine()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.ChangeCameraToPeeligMachine();
        FindObjectOfType<PeelingMachine>().StartSpawn(PotatoresTrack.Instance.potatoesCounter);

    }
}
