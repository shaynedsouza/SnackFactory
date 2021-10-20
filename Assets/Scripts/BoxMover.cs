using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMover : MonoBehaviour
{
    public float forceMult = 200;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void Start()
    {
        Destroy(this.gameObject, 2f);
    }
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * Time.fixedDeltaTime * forceMult;
    }
}
