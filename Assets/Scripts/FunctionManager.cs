using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionManager : MonoBehaviour
{

    public Transform GetNearestGameObject(Transform currentFlotage, GameObject[] objects)
    {
        Transform nearestObject = objects[0].transform;
        float firstLength = Vector3.Distance(currentFlotage.position, objects[0].transform.position);
        for (int i = 0; i < objects.Length; i++)
        {
            float length = Vector3.Distance(currentFlotage.position, objects[i].transform.position);
            if (firstLength > length)
            {
                firstLength = length;
                nearestObject = objects[i].transform;
            }
        }
        return nearestObject;
    }

    public Vector3 FindNearestPoint(GameObject unit2BChecked, List<Vector3> points)
    {
        Vector3 closestPoint = points[0];
        float minDis = Vector3.Distance(unit2BChecked.transform.position, points[0]);
        for (int i = 0; i < points.Count; i++)
        {
            float tempMinDis = Vector3.Distance(unit2BChecked.transform.position, points[i]);
            if (minDis>tempMinDis)
            {
                minDis = tempMinDis;
                closestPoint = points[i];
            }
        }

        return closestPoint;
    }

    public bool testPerfectSquare(int numToTest, out int root)
    {
        root = (int)Mathf.Pow(numToTest, (1f / 3f));
        bool perfect = root * root * root == numToTest ? true : false;
        return perfect;
    }
}
