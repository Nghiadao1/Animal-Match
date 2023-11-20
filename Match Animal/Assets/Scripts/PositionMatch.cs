using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMatch : MonoBehaviour
{
    public bool isHaveAnimal;
    public GameObject animal;
    void Update()
    {
        if (animal != null) isHaveAnimal = true;
        else isHaveAnimal = false;
    }
}
