using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMaths : MonoBehaviour
{

    public static Vector3 vectorAddition3D(Vector3 vectorOne, Vector3 vectorTwo)
    {
        Vector3 vectorAdditionResult = new Vector3();
        vectorAdditionResult.x = vectorOne.x + vectorTwo.x;
        vectorAdditionResult.y = vectorOne.y + vectorTwo.y;
        vectorAdditionResult.z = vectorOne.z + vectorTwo.z;
        return vectorAdditionResult;
    }

    public static Vector3 vectorSubtraction3D(Vector3 vectorOne, Vector3 vectorTwo)
    {
        Vector3 vectorSubtractionResult = new Vector3();
        vectorSubtractionResult.x = vectorOne.x - vectorTwo.x;
        vectorSubtractionResult.y = vectorOne.y - vectorTwo.y;
        vectorSubtractionResult.z = vectorOne.z - vectorTwo.z;
        return vectorSubtractionResult;
    }

    public static float dotProduct3D(Vector3 vectorOne, Vector3 vectorTwo) 
    {
        float dotProductResult;
        return dotProductResult = (vectorOne.x * vectorTwo.x) + (vectorOne.y * vectorTwo.y) + (vectorOne.z * vectorTwo.z);
    }

    public static float unitVectorOf3DVector(Vector3 vector, float magntiudeOfVector) 
    {
        float unitDirectionVectorResult;
        return unitDirectionVectorResult = (vector.x / magntiudeOfVector) + (vector.y / magntiudeOfVector) + (vector.z / magntiudeOfVector);
    }

    public static Vector3 vectorReflectionAxisAligned(Vector3 vector, bool horizontalCollision, bool verticleCollision) 
    {
        Vector3 reflextedVector = new Vector3();
        if (horizontalCollision == true)
        {
            reflextedVector.x = -vector.x;
            reflextedVector.y = vector.y;
            reflextedVector.y = vector.z;
        }

        if (verticleCollision == true)
        {
            reflextedVector.x = vector.x;
            reflextedVector.y = vector.y;
            reflextedVector.y = -vector.z;
        }
        return reflextedVector;
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

    public static float unitDirectionVector(Vector3 vectorOne, Vector3 vectorTwo)
    {
        float unitDirectionVectorResult;
        return unitDirectionVectorResult = Mathf.Atan(vectorTwo.z - vectorOne.z / vectorTwo.x - vectorOne.x);
    }

    public static float magnitudeOf3DVector(Vector3 vector) 
    {
        float magnitudeOf3DVectorResult;
        return magnitudeOf3DVectorResult = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2) + Mathf.Pow(vector.z, 2));
    }

    public static Vector3 scalerMultiplierOf3DVector(Vector3 vector, float scaler) 
    {
        Vector3 scaledVector = new Vector3();
        scaledVector.x = scaler * vector.x;
        scaledVector.y = scaler * vector.y;
        scaledVector.z = scaler * vector.z;
        return scaledVector;
    }

    public static bool vectorNearlyEqualWithRaduis(Vector3 vectorOne, Vector3 vectorTwo, float toleranceAmount) 
    {

        return magnitudeOf3DVector(vectorSubtraction3D(vectorOne, vectorTwo)) < Mathf.Abs(toleranceAmount); //change later

    }

    public static Vector3 zero3DVector(Vector3 vector) 
    {
        return vector = new Vector3();
    }

    public static bool aPointIsOnABoundedLine(Vector3 ballPosition, Vector3 boundedLine, Vector3 rectangleEndPoint)
    {
        float gradient, lineIntercept;
        gradient = boundedLine.z / boundedLine.x;
        lineIntercept = boundedLine.z / gradient * boundedLine.x;
        boundedLine.z = gradient * boundedLine.x + lineIntercept;

        for (float i = 1; boundedLine.x < rectangleEndPoint.x;)
        {
            for (float j = 1; boundedLine.z < rectangleEndPoint.z;)
            {
                if (ballPosition.x - boundedLine.x <= 1 && ballPosition.z - boundedLine.z <= 1)
                {
                    return true;
                }
                boundedLine.x = Mathf.Abs(boundedLine.x + 0.01f);
                boundedLine.z = Mathf.Abs(boundedLine.x + 0.01f);
            }
        }
        return false;
    }
}

/*public static bool aPointIsOnABoundedLine(Vector3 ballPosition, Vector3 boundedLine, float minX, float minY, float maxX, float maxY)
{
    float gradient, lineIntercept, xPosition, yPosition;
    gradient = boundedLine.z / boundedLine.x;
    lineIntercept = boundedLine.z / gradient * boundedLine.x;
    boundedLine.z = gradient * boundedLine.x + lineIntercept;

    for (xPosition = boundedLine.x < rectangleEndPoint.x;)
    {
        for (yPosition = boundedLine.z < rectangleEndPoint.z;)
        {
            if (ballPosition.x - boundedLine.x <= 1 && ballPosition.z - boundedLine.z <= 1)
            {
                return true;
            }
            boundedLine.x = Mathf.Abs(boundedLine.x + 0.01f);
            boundedLine.z = Mathf.Abs(boundedLine.x + 0.01f);
        }
    }
    return false;
}*/