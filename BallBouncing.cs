using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncing : MonoBehaviour
{
    private Vector3 spherePosition = new Vector3(0.0f, -1.0f, 0.0f), gravity = new Vector3(0.0f, -0.05f, 0.0f), velocity;
    private float height, coeffientOfRestitution = 2.0f;
    private float getUnintialVelocity(float height) { return Mathf.Sqrt(2 * height * gravity.y); } //Gets the uninital velocity
    private float velocityAfterCollision(float height) { return Mathf.Sqrt(2 * (Mathf.Pow(coeffientOfRestitution, 2) * height) * gravity.y); } //gets the velocity after collision
    private void Start()
    {
        velocity = new Vector3(0.3f, getUnintialVelocity(spherePosition.y), 0.0f);
    }
    private void Update()
    {
        if (spherePosition.y <= 0.0f) { velocity.y = velocity.y + velocityAfterCollision(spherePosition.y); } //Velocity on collsion
        if (spherePosition.y > coeffientOfRestitution * -velocity.y) { velocity.y = velocity.y + gravity.y; } //Velocity after rebound
        spherePosition.x = spherePosition.x + velocity.x;
        spherePosition.y = spherePosition.y + velocity.y;
        transform.position = spherePosition;
    }
}