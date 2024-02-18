using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionReset : MonoBehaviour
{
    private Dictionary<Transform, Vector3> initialPositions = new Dictionary<Transform, Vector3>();

    void Start()
    {
        // Save initial positions of all child objects
        SaveInitialPositions();
    }

    void SaveInitialPositions()
    {
        initialPositions.Clear();

        // Save the initial position for each child object
        foreach (Transform child in transform)
        {
            initialPositions[child] = child.position;
        }
    }

    public void ResetObjectPositions()
    {
        // Move all child objects back to their initial positions
        foreach (var entry in initialPositions)
        {
            entry.Key.position = entry.Value;
        }
    }
}
