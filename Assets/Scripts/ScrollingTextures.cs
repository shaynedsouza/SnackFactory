using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTextures : MonoBehaviour
{
    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;
    Renderer rend;
    public bool startBelt;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            moveTexture();
        }
    }

    void moveTexture()
    {
        float OffsetX = Time.time * scrollSpeedX;
        float OffsetY = Time.time * scrollSpeedY;
        rend.material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }

}
