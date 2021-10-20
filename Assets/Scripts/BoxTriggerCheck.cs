using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Potato"))
        {
            DestroyPotato(other);
            PotatoresTrack.Instance.potatoeLessCount();
        }
        if (other.gameObject.CompareTag("PotatoPeeled"))
        {
            DestroyPotato(other);
            PeeledPotatoCount.Instance.PelledpotatoeLessCount();
        }
        if (other.gameObject.CompareTag("Fries"))
        {
            DestroyPotato(other);
            FriesCount.Instance.friesLessCount();
        }
        if (other.gameObject.CompareTag("FriedFries"))
        {
            DestroyPotato(other);
            FriesFryingCount.Instance.friesFryingLessCount();
        }
    }

    void DestroyPotato(Collider other)
    {
        Destroy(other.gameObject);
        AudioManager.instance.PlaySFX(AudioManager.instance.boxSmash, 0.03f);
    }

}
