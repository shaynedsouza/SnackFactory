using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FriesTrigger : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("PotatoPeeled"))
        {
            FriesMachine.Instance.PotatoEncountered();
            gameObject.transform.DORewind();
            gameObject.transform.DOPunchScale(Vector3.one / 15, .3f, 10, 1);
            //PotatoresTrack.Instance.startingTotalPotatoes--;
            PeeledPotatoCount.Instance.peeledPotatoesCount++;

            if (PeeledPotatoCount.Instance.peeledPotatoesStart == PeeledPotatoCount.Instance.peeledPotatoesCount)
            {
                GameManager.Instance.ChangeCameraToFrieMachine();
                FriesMachine.Instance.StartSpawn(PeeledPotatoCount.Instance.peeledPotatoesCount + 20 + 60);
            }

            Destroy(other.gameObject);
            //peelingMachine.transform.DORewind();
            //peelingMachine.transform.DOShakePosition(0.1f, 0.5f, 0, 0, vibrato:1, fadeOut:false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameManager.Instance.ChangeCameraToFrieMachine();
            FriesMachine.Instance.StartSpawn(PeeledPotatoCount.Instance.peeledPotatoesCount + 20 + 60);
        }
    }
}
