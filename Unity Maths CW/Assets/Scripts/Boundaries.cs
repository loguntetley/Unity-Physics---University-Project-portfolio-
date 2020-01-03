using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector3 boundariePositionTop, boundariePositionTopLeft, boundariePositionTopRight, boundariePositionMiddleLeft, boundariePositionMiddleRight, boundariePositionBottom, boundariePositionBottomLeft, boundariePositionBottomRight;



    void Start()
    {
        boundariePositionTop = new Vector3(0.0f, 1.0f, 25.0f);
    }

    void Update()
    {
        boundariePositionTop.x = boundariePositionTop.x + 1.0f;
        //this.transform.position = boundariePositionTop;
    }
}
