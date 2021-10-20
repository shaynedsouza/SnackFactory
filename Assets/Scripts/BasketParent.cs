using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketParent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("FriesFried"))
        {
            other.transform.parent = transform;
        }
    }
}
