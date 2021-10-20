using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BasketMover : MonoBehaviour
{
    public float speed;

    void Start()
    {
        gameObject.transform.DOMoveZ(-20, speed).SetEase(Ease.Linear);
    }
}
