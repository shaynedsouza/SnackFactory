using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LastJump : MonoBehaviour
{
    public Vector3 jumpPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("FriesFried"))
        {
            //other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.DOJump(jumpPos, 2, 1, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            });
        }
    }
}

//-5.18 1.75 -0.52
