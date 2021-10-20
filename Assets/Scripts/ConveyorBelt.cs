using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ConveyorBelt : MonoBehaviour
{


    public float speed;
    Rigidbody rb;
    public Vector3 direction;
    public bool autoMove;

    public bool startMove;
    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (!autoMove)
        {
            if (Input.GetMouseButton(0) && canMove)
            {
                if (!startMove)
                {
                    if (EventSystem.current.IsPointerOverGameObject())
                        return;
                    if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                    {
                        if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                            return;
                    }
                    Vector3 pos = rb.position;
                    rb.position += direction * speed * Time.fixedDeltaTime;
                    rb.MovePosition(pos);
                }
            }
        }
        else
        {
            Vector3 pos = rb.position;
            rb.position -= direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(pos);
        }
    }
}
