using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorMaths
{
    public static Vector3 vectorAddition3D(Vector3 vectorOne, Vector3 vectorTwo) { return new Vector3(vectorOne.x + vectorTwo.x, vectorOne.y + vectorTwo.y, vectorOne.z + vectorTwo.z); }

    public static Vector3 vectorSubtraction3D(Vector3 vectorOne, Vector3 vectorTwo) { return new Vector3(vectorOne.x - vectorTwo.x, vectorOne.y - vectorTwo.y, vectorOne.z - vectorTwo.z); }

    public static float dotProduct3D(Vector3 vectorOne, Vector3 vectorTwo) { return (vectorOne.x * vectorTwo.x) + (vectorOne.y * vectorTwo.y) + (vectorOne.z * vectorTwo.z); }

    public static Vector3 unitVectorOf3DVector(Vector3 vector, float magntiudeOfVector) { return new Vector3(vector.x / magntiudeOfVector, vector.y / magntiudeOfVector, vector.z / magntiudeOfVector); }

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

    public static Vector3 getDirectionVector(float angle) { return new Vector3(-Mathf.Cos(angle * Mathf.Deg2Rad), 0.0f, Mathf.Sin(angle * Mathf.Deg2Rad)); }

    public static Vector3 vectorProjection(Vector3 velocity, Vector3 normalVector) { return (-dotProduct3D(velocity, normalVector) / Mathf.Pow(magnitudeOf3DVector(normalVector), 2)) * normalVector; }

    public static Vector3 vectorReflectionAxisNotAligned(Vector3 velocity, Transform boundary) { return 2 * vectorProjection(velocity, getDirectionVector(boundary.rotation.eulerAngles.y - 90.0f)) + velocity; }

    public static Vector3 unitDirectionVector(Vector3 vectorOne, Vector3 vectorTwo) { return new Vector3 (Mathf.Atan(vectorTwo.z - vectorOne.z), (Mathf.Atan(vectorTwo.y - vectorOne.y)), Mathf.Atan(vectorTwo.x - vectorOne.x)); }

    public static float magnitudeOf3DVector(Vector3 vector) { return Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2) + Mathf.Pow(vector.z, 2)); }

    public static Vector3 scalerMultiplierOf3DVector(Vector3 vector, float scaler) { return new Vector3(scaler * vector.x, scaler * vector.y, scaler * vector.z); }

    public static bool vectorNearlyEqualWithRaduis(Vector3 vectorOne, Vector3 vectorTwo, float toleranceAmount) { return magnitudeOf3DVector(vectorSubtraction3D(vectorOne, vectorTwo)) < Mathf.Abs(toleranceAmount); }

    public static Vector3 zero3DVector(Vector3 vector) { return new Vector3(); }

    public static bool aPointIsOnABoundedLine(Vector3 spherePosition, Vector3 boundedLine)
    {
        float gradient = boundedLine.z / boundedLine.x, b;
        return Mathf.Abs((gradient * spherePosition.x + (b = boundedLine.z - (gradient) * (boundedLine.x)))) < 0.01 || Mathf.Abs((gradient * spherePosition.z + (b = boundedLine.x - (gradient) * (boundedLine.z)))) < 0.01;
    }
}

