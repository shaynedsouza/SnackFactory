using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FriesFryingTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("FriesRaw"))
        {
            FriesFryingMachine.Instance.ActivateFry();
            gameObject.transform.DORewind();
            gameObject.transform.DOPunchScale(Vector3.one / 15, .3f, 10, 1);
            //PotatoresTrack.Instance.startingTotalPotatoes--;
            FriesCount.Instance.friesCount++;

            if (FriesCount.Instance.friesStart == FriesCount.Instance.friesCount)
            {
                GameManager.Instance.ChangeCameraToFriesFrying();
                // FriesFryingMachine.Instance.StartSpawn(FriesCount.Instance.friesCount + 20);
                FriesFryingMachine.Instance.StartCook(FriesCount.Instance.friesCount + 20);
            }

            Destroy(other.gameObject);
            //peelingMachine.transform.DORewind();
            //peelingMachine.transform.DOShakePosition(0.1f, 0.5f, 0, 0, vibrato:1, fadeOut:false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.ChangeCameraToFriesFrying();
            FriesFryingMachine.Instance.StartCook(FriesCount.Instance.friesCount + 20);
        }
    }
}
