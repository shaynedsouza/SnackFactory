using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FinalCameraAngle : MonoBehaviour
{
    public CinemachineVirtualCamera myCinemachine;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Tracker") || other.gameObject.name.Contains("PeelingTracker"))
        {
            //9-10
            //2xl
            myCinemachine.m_Follow = null;
            Destroy(other.gameObject);

            GameManager.Instance.ChangeToFinalCameraAngle();


        }
    }
}
