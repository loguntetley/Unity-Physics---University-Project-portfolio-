using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncing : MonoBehaviour
{
    private Vector3 spherePosition, gravity, velocity;
    private float height, coeffientOfRestitution = 2.0f;
    private float getUnintialVelocity(float height) { return Mathf.Sqrt(2 * height * gravity.y); }
    private float velocityAfterCollision(float height) { return Mathf.Sqrt(2 * (Mathf.Pow(coeffientOfRestitution, 2) * height) * gravity.y); }
    private void Start()
    {
        spherePosition = new Vector3(0.0f, -1.0f, 0.0f);
        gravity = new Vector3(0.0f, -0.05f, 0.0f);
        velocity = new Vector3(0.3f, getUnintialVelocity(spherePosition.y), 0.0f);
    }
    private void Update()
    {
        if (spherePosition.y <= 0.0f){ velocity.y = velocity.y + velocityAfterCollision(spherePosition.y); }
        if (spherePosition.y > coeffientOfRestitution * -velocity.y) { velocity.y = velocity.y + gravity.y; }   
        spherePosition.x = spherePosition.x + velocity.x;
        spherePosition.y = spherePosition.y + velocity.y;
        this.transform.position = spherePosition;
    }

    /*if (Mathf.Abs(nextBounceHeight - prevBounceHeight) > 0.01f)spherePosition.x < 25.0f)(Mathf.Abs(bounceHeight - prevBounceHeight) > -0.01f))
        {
        private float height, bounceHeight, prevBounceHeight, nextBounceHeight, coeffientOfRestitution = 2.0f;
            prevBounceHeight = 1.0f;
        nextBounceHeight = 0.0f;


            if (spherePosition.y <= 0.0f)
            {
               prevBounceHeight = bounceHeight;
                
                velocity.y = velocity.y + velocityAfterCollision(spherePosition.y);
            }
            if (spherePosition.y > coeffientOfRestitution* -velocity.y)
            {
                bounceHeight = coeffientOfRestitution * -velocity.y;
                Debug.Log(bounceHeight);
                velocity.y = velocity.y + gravity.y;
                nextBounceHeight = bounceHeight;
            }   
            spherePosition.x = spherePosition.x + velocity.x;
            spherePosition.y = spherePosition.y + velocity.y;
            this.transform.position = spherePosition;
        }*/
}