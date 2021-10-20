using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float speed=100;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //m_Rigidbody.velocity = transform.forward * Time.deltaTime* speed;
            //transform.position += transform.forward * Time.deltaTime * speed;
            m_Rigidbody.MovePosition(transform.position + (transform.forward * Time.deltaTime * speed));
        } 
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            //m_Rigidbody.velocity = transform.forward * Time.fixedDeltaTime * speed;
        } 
    }
}
