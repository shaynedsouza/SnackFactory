using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class StopFollow : MonoBehaviour
{

    public CinemachineVirtualCamera myCinemachine;
    bool lastCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Tracker") || other.gameObject.name.Contains("PeelingTracker"))
        {
            myCinemachine.m_Follow = null;

            gameObject.SetActive(false);
            other.gameObject.transform.parent.gameObject.transform.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Basket"))
        {
            Destroy(other.gameObject);
        }
    }
}
