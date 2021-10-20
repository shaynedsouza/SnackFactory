using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MovingMultiplier : MonoBehaviour
{
    public float speed;
    public float moveXPos;
    public float moveZPos;
    public bool moveX;
    public bool moveZ;

    void Start()
    {
        if(moveX)
        {
            gameObject.transform.DOLocalMoveX(moveXPos, speed)
                .SetEase(Ease.Linear)
                .OnComplete(() => Destroy(this.gameObject));
        }

        if (moveZ)
        {
            gameObject.transform.DOLocalMoveZ(moveZPos, speed)
                .SetEase(Ease.Linear)
                .OnComplete(() => Destroy(this.gameObject));
        }
    }

  
}
