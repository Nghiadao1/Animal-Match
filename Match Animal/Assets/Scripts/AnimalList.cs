using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalList : MonoBehaviour
{
    public int numberOfDog;
    public int numberOfCat;
    public int numberOfBird;
    public int numberOfFish;
    public int numberOfRabbit;
    public List<GameObject> animals;
    public List<GameObject> animalMatch;
    public GameManager gameManager;
    void Start()
    {
        animals.Capacity = gameManager.sizeMatrix * gameManager.sizeMatrix;
        AddAnimal();
    }
    public void AddAnimal()
    {
        for (int i = 0; i < numberOfDog; i++)
        {
            animals.Add(Resources.Load<GameObject>("Prefabs/Animal/Dog"));
        }
        for (int i = 0; i < numberOfCat; i++)
        {
            animals.Add(Resources.Load<GameObject>("Prefabs/Animal/Cat"));
        }
        for (int i = 0; i < numberOfBird; i++)
        {
            animals.Add(Resources.Load<GameObject>("Prefabs/Animal/Bird"));
        }
        for (int i = 0; i < numberOfFish; i++)
        {
            animals.Add(Resources.Load<GameObject>("Prefabs/Animal/Fish"));
        }
        for (int i = 0; i < numberOfRabbit; i++)
        {
            animals.Add(Resources.Load<GameObject>("Prefabs/Animal/Rabbit"));
        }
    }
}
