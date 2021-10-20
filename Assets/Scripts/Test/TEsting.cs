using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TEsting : MonoBehaviour
{

    public Vector3 jumpPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.transform.DOJump(jumpPos, 5, 1, 0.5f).SetEase(Ease.Linear);
        }
    }
}
