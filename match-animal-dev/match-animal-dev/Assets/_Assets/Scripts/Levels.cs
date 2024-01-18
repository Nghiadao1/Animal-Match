using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public static List<GameObject> levels;
    void Start()
    {
        levels = new List<GameObject>();
        foreach (GameObject level in GameObject.FindGameObjectsWithTag("Levels"))
            levels.Add(level);
    }
}
