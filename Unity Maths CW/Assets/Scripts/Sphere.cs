using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Vector3 spherePosition, boundariePosition, velocity;
    private Vector3 boundariePositionTop, boundariePositionTopLeft, boundariePositionTopRight, boundariePositionMiddleLeft, boundariePositionMiddleRight, boundariePositionBottom, boundariePositionBottomLeft, boundariePositionBottomRight;
    private float posFriction, negFriction;
    public float initialForceX, initialForceZ, friction, mass;

    public static Vector3 vectorReflectionAxisAligned(Vector3 vector, bool horizontalCollision, bool verticleCollision)
    {
        Vector3 reflextedVector = new Vector3();
        if (horizontalCollision == true)
        {
            reflextedVector.x = -vector.x;
            reflextedVector.y = vector.y;
            reflextedVector.z = vector.z;
        }

        if (verticleCollision == true)
        {
            reflextedVector.x = vector.x;
            reflextedVector.y = vector.y;
            reflextedVector.z = -vector.z;
        }
        return reflextedVector;
    }
    public static float dotProduct3D(Vector3 vectorOne, Vector3 vectorTwo)
    {
        float dotProductResult;
        return dotProductResult = (vectorOne.x * vectorTwo.x) + (vectorOne.y * vectorTwo.y) + (vectorOne.z * vectorTwo.z);
    }
    public static float magnitudeOf3DVector(Vector3 vector)
    {
        float magnitudeOf3DVectorResult;
        return magnitudeOf3DVectorResult = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2) + Mathf.Pow(vector.z, 2));
    }
    public static Vector3 vectorReflectionAxisNotAligned(Vector3 vector)//, Vector3 boundary)
    {
        Vector3 normalisedVector = new Vector3();
        normalisedVector.x = vector.x / magnitudeOf3DVector(vector);
        normalisedVector.y = vector.y;
        normalisedVector.z = vector.z / magnitudeOf3DVector(vector);

        //float vectorProjection;
        //vectorProjection = dotProduct3D(vector, boundary) / magnitudeOf3DVector(boundary);

        Vector3 nonAxisAlignedVector = new Vector3();
        nonAxisAlignedVector = vector - 2 * dotProduct3D(vector, normalisedVector) * normalisedVector;
        return nonAxisAlignedVector;
        //vf = vi - 2 <vi n> * n


    }
    private Vector3 velocityUpdater(Vector3 velocity, float friction)
    {
        if (velocity.x > 0) { friction = posFriction; }
        if (velocity.x < 0) { friction = negFriction; }
        velocity.x = velocity.x - friction;
        if (Mathf.Abs(velocity.x - friction) < 0.05) { velocity.x = 0.0f; }
        if (velocity.z > 0) { friction = posFriction; }
        if (velocity.z < 0) { friction = negFriction; }
        velocity.z = velocity.z - friction;
        if (Mathf.Abs(velocity.z - friction) < 0.05) { velocity.z = 0.0f; }
        return velocity;
    }
    public static bool aPointIsOnABoundedLine(Vector3 ballPosition, Vector3 boundedLine)
    {
        float gradient = 1.0f, b;// lineIntercept;
        //gradient = boundedLine.z / boundedLine.x;
        //lineIntercept = ballPosition.z / gradient * boundedLine.x;
        //boundedLine.z = gradient * ballPosition.x + lineIntercept;

        //(25,0). 
        //y=mx+b or 0=1 × 25+b, or solving for b: b=0-(1)(25). b=-25.
        //float xIntercept, zIntercept, zPos, xPos, b, boundaryLinePos;
        //boundedLine.z = gradient * ballPosition.x + (b = boundedLine.z - (gradient) * (boundedLine.x));
        if (Mathf.Abs((gradient * ballPosition.x + (b = boundedLine.z - (gradient) * (boundedLine.x)))) < 0.01 || Mathf.Abs((gradient * ballPosition.z + (b = boundedLine.x - (gradient) * (boundedLine.z)))) < 0.01) // && Mathf.Abs(boundedLine.z - ballPosition.z) < 0.01)//(Mathf.Abs(ballPosition.x - boundedLine.x) < 0.01 && Mathf.Abs(ballPosition.z - boundedLine.z) < 0.01)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Start()
    {
        boundariePositionTop = new Vector3(0.0f, 1.0f, -25.0f);
        boundariePositionTopLeft = new Vector3(17.5f, 1.0f, -17.5f);
        boundariePositionTopRight = new Vector3(-17.5f, 1.0f, -17.5f);
        boundariePositionMiddleLeft = new Vector3(25.0f, 1.0f, 0.0f);
        boundariePositionMiddleRight = new Vector3(-25.0f, 1.0f, 0.0f);
        boundariePositionBottom = new Vector3(0.0f, 1.0f, 25.0f);
        boundariePositionBottomLeft = new Vector3(17.5f, 1.0f, 17.5f);
        boundariePositionBottomRight = new Vector3(-17.5f, 1.0f, 17.5f);
        spherePosition = new Vector3(0.0f, 0.0f, 0.0f);
        velocity = new Vector3(initialForceX, 0.0f, initialForceZ);
        posFriction = friction;
        negFriction = -friction;

    }

    private void Update()
    {
        if (aPointIsOnABoundedLine(spherePosition, boundariePositionTop))//(spherePosition.z <= boundariePositionTop.z)//spherePosition.x == boundariePositionTop.x && spherePosition.z == boundariePositionTop.z)
        {
            //Debug.Log("bt");
            velocity = vectorReflectionAxisAligned(velocity, false, true);
        }
        if (aPointIsOnABoundedLine(spherePosition, boundariePositionTopLeft))//(spherePosition.x >= boundariePositionTopLeft.x && spherePosition.z <= boundariePositionTopLeft.z)//spherePosition.x == boundariePositionTopLeft.x && spherePosition.z == boundariePositionTopLeft.z)
        {
            //Debug.Log("btl");
            velocity = vectorReflectionAxisNotAligned(velocity);
        }
        if (aPointIsOnABoundedLine(spherePosition, boundariePositionTopRight))//(spherePosition.x <= boundariePositionTopRight.x && spherePosition.z <= boundariePositionTopRight.z)
        {
            //Debug.Log("btr");
            velocity = vectorReflectionAxisNotAligned(velocity);
        }
        if (aPointIsOnABoundedLine(spherePosition, boundariePositionMiddleLeft))//(spherePosition.x >= boundariePositionMiddleLeft.x)// && spherePosition.z == boundariePositionMiddleLeft.z)
        {
            //Debug.Log("bml");
            velocity = vectorReflectionAxisAligned(velocity, true, false);

        }
        if (aPointIsOnABoundedLine(spherePosition, boundariePositionMiddleRight))//(spherePosition.x <= boundariePositionMiddleRight.x)// && spherePosition.z == boundariePositionMiddleRight.z)
        {
            //Debug.Log("bmr");
            velocity = vectorReflectionAxisAligned(velocity, true, false);
        }
        if (aPointIsOnABoundedLine(spherePosition, boundariePositionBottom))//(spherePosition.z >= boundariePositionBottom.z)//spherePosition.x == boundariePositionBottom.x && spherePosition.z == boundariePositionBottom.z)
        {
            //Debug.Log("bb");
            velocity = vectorReflectionAxisAligned(velocity, false, true);
        }
        if (aPointIsOnABoundedLine(spherePosition, boundariePositionBottomLeft))//(spherePosition.x >= boundariePositionBottomLeft.x && spherePosition.z >= boundariePositionBottomLeft.z)
         {
             //Debug.Log("bbl");
             velocity = vectorReflectionAxisNotAligned(velocity);
         }
         if (aPointIsOnABoundedLine(spherePosition, boundariePositionBottomRight))//(spherePosition.x <= boundariePositionBottomRight.x && spherePosition.z >= boundariePositionBottomRight.z)
         {
             //Debug.Log("bbr");
             velocity = vectorReflectionAxisNotAligned(velocity);
         }
        //velocity = velocityUpdater(velocity, friction);
        spherePosition.x = spherePosition.x + velocity.x;
        //Debug.Log(velocity.x);
        spherePosition.z = spherePosition.z + velocity.z;
        this.transform.position = spherePosition;

    }
}