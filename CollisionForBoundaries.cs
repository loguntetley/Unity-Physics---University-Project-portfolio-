using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionForBoundaries
{
    private static float sqDistToBoundarie(Vector3 spherePosition, Vector3 boundariesLine, float tempHalfOfBoundary)
    {
        float excess = 0.0f; //calculates the boundaires Square distance
        if (VectorMaths.dotProduct3D(spherePosition, boundariesLine) < -tempHalfOfBoundary) { excess = VectorMaths.dotProduct3D(spherePosition, boundariesLine) + tempHalfOfBoundary; }
        else if (VectorMaths.dotProduct3D(spherePosition, boundariesLine) > tempHalfOfBoundary) { excess = VectorMaths.dotProduct3D(spherePosition, boundariesLine) - tempHalfOfBoundary; }
        return excess;
    }
    private static float distanceChecker(Vector3 spherePosition, Vector3 halfOfBoundary, Transform boundaries)
    {   //calcuation for distance
        Vector3 distanceDifference = VectorMaths.vectorSubtraction3D(spherePosition, boundaries.position);
        float rightResult = Mathf.Pow(sqDistToBoundarie(distanceDifference, boundaries.right, halfOfBoundary.x), 2);
        float upResult = Mathf.Pow(sqDistToBoundarie(distanceDifference, boundaries.up, halfOfBoundary.y), 2);
        float leftResult = Mathf.Pow(sqDistToBoundarie(distanceDifference, boundaries.forward, halfOfBoundary.z), 2);
        return Mathf.Sqrt(rightResult + upResult + leftResult);
    }
    public static bool collisionChecker(Vector3 spherePosition, float SphereRadius, Transform boundaries, Vector3 halfOfBoundary)
    {
        if (distanceChecker(spherePosition, halfOfBoundary, boundaries) <= SphereRadius) { return true; } //checks if the ditance is less than the radius and returns a bool
        return false;
    }

}





