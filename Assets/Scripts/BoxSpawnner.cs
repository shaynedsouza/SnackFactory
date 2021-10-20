using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnner : MonoBehaviour
{

    public GameObject boxPrefab;
    public float countdown = 5;
    public float m_Thrust;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            MakeBox();
            int randomTimer = Random.Range(3, 5);
            countdown = randomTimer;
        }
    }

    public void MakeBox()
    {
        //Uncomment to spawn box
        GameObject genrateBasket = Instantiate(boxPrefab, transform.position, transform.rotation);
    }
}
