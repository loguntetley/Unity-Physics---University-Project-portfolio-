using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Transform[] allBoundaires;
    public float initialForceX, initialForceZ ,friction;
    private float positiveFriction, negitiveFriction;
    private Vector3 spherePosition = new Vector3(0.0f, 0.0f, 0.0f), velocity, frictionVector = new Vector3(0.0f, 0.0f, 0.0f);
    private void Start()
    {
        velocity = new Vector3(initialForceX, 0.0f, initialForceZ); //To start the ball with a velocity in x and z
    }

    private void Update()
    {
        frictionVector = velocity * friction;
        spherePosition += velocity = velocity -= frictionVector; //calculate the friction with the velocity to slow down the ball
        transform.position = spherePosition;

        foreach (Transform boundaires in allBoundaires)
        {
            //check though all the boudaries and see which one collides
            if (CollisionForBoundaries.collisionChecker(spherePosition, 1.0f, boundaires, boundaires.localScale / 2)) { velocity = VectorMaths.vectorReflectionAxisNotAligned(velocity, boundaires); /*set the velocity once reflexted*/}  
        }
    }
}