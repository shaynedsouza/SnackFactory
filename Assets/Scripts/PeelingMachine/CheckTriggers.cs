using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CheckTriggers : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Potato"))
        {
            gameObject.transform.DORewind();
            gameObject.transform.DOPunchScale(Vector3.one / 25, .3f, 10, 1);
            //PotatoresTrack.Instance.startingTotalPotatoes--;
            PotatoresTrack.Instance.potatoesCounter++;

            if (PotatoresTrack.Instance.startingTotalPotatoes == PotatoresTrack.Instance.potatoesCounter)
            {
                StartCoroutine(FindObjectOfType<PeelingEffect>().StartPeeling());
            }

            Destroy(other.gameObject);
            //peelingMachine.transform.DORewind();
            //peelingMachine.transform.DOShakePosition(0.1f, 0.5f, 0, 0, vibrato:1, fadeOut:false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(FindObjectOfType<PeelingEffect>().StartPeeling());
        }
    }
}
