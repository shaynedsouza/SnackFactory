using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MultiplierMovement : MonoBehaviour
{
    //public static MultiplierMovement Instance;
    //private void Awake()
    //{
    //    if(Instance==null)
    //    {
    //        Instance = this;
    //    }
    //}

    public Vector3 movementPos;
    public float speed;

    public GameObject[] objectPrefab;

    public float countdown = 5;

    public bool isMoving=false;

    public string id;
    //Sequence myseq;
    // Start is called before the first frame update
    void Start()
    {
        //transform.DOLocalMove(movementPos, speed)
        //    .SetLoops(-1, LoopType.Restart)
        //    .SetEase(Ease.Linear)
        //    ;
    }

    private void Update()
    {
      if(!isMoving)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                MoveMultiplier();
                int randomTimer = Random.Range(2, 3);
                countdown = randomTimer;
            }
        }
    }

    void MoveMultiplier()
    {
        int randomPrefabs = Random.Range(0, objectPrefab.Length);
        GameObject multiplierMover = Instantiate(objectPrefab[randomPrefabs], transform.position,transform.rotation) as GameObject;
        multiplierMover.transform.GetChild(4).GetComponent<ObjectMultiplier>().mm = this;
        //myseq = DOTween.Sequence();
        //myseq.Append(multiplierMover.transform.DOMove(movementPos, speed))
                //.SetId(id)
                //.SetEase(Ease.Linear)
                
        //Destroy(multiplierMover, 3.5f);
       // multiplierMover.transform.DOMove(movementPos, speed).SetId(id).SetEase(Ease.Linear).OnComplete(() => Destroy(multiplierMover));
    }
    public void stopTween()
    {
        //myseq.Kill();
        isMoving = true;
        gameObject.SetActive(false);
        DOTween.Pause(id);
    }
  
}
