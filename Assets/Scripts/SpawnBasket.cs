using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBasket : MonoBehaviour
{
    public float countdown = 5;
    public GameObject basket;
    public float m_Thrust;
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            MakeBasket();
            int randomTimer = Random.Range(2, 3);
            countdown = randomTimer;
        }
    }

    public void MakeBasket()
    {
        GameObject genrateBasket = Instantiate(basket, transform.position, Quaternion.identity);
        //genrateBasket.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * m_Thrust, ForceMode.Impulse);

        //Destroy(genrateBasket,0.5f);
    }
}
