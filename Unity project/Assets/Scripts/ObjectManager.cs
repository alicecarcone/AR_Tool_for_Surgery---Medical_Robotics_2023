using UnityEngine;
using System.Collections.Generic;

public class ObjectManager : MonoBehaviour
{
    public List<GameObject> objectsToDisable;

    void Start()
    {
        // Disable objects at the start of the game
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }
}
