using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AnimalList animalList;
    public Transform position;
    public int sizeMatrix;
    public static bool isMatched = false;
    void Start()
    {
        MatrixAnimal();
    }
    void Update()
    {
       // MatchAnimal();
       CheckWin();
    }
    public void MatrixAnimal()
    {
        GameObject[,] matrix = new GameObject[sizeMatrix, sizeMatrix];
        List<GameObject> list = new List<GameObject>();
        foreach (GameObject animal in animalList.animals)
        {
            list.Add(animal);
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int random = Random.Range(0, list.Count);
                GameObject animal = list[random];
                GameObject animalClone = Instantiate(animal);
                animalClone.transform.SetParent(position);
                animalClone.name = animal.name;
                animalClone.transform.position = new Vector3(position.position.x + j, position.position.y - i, 0);
                matrix[i, j] = animalClone;
                list.RemoveAt(random);
            }
        }
    }
    public void MatchAnimal()
    {
        for (int i = 0; i < animalList.animalMatch.Count; i++)
        {
            Animal animalInfo = animalList.animalMatch[i].GetComponent<Animal>();
            AnimalType animalType = animalInfo.animalType;
            int count = 0;
            for (int j = 0; j < animalList.animalMatch.Count; j++)
            {
                Animal animalInfo2 = animalList.animalMatch[j].GetComponent<Animal>();
                AnimalType animalType2 = animalInfo2.animalType;
                if (animalType == animalType2) count++;
            }
            if (count % 3 == 0 && count != 0)
            {
                for (int j = 0; j < animalList.animalMatch.Count; j++)
                {
                    Animal animalInfo2 = animalList.animalMatch[j].GetComponent<Animal>();
                    AnimalType animalType2 = animalInfo2.animalType;
                    if (animalType == animalType2)
                    {
                        Destroy(animalList.animalMatch[j]);
                        isMatched = true;
                        animalList.animalMatch.RemoveAt(j);
                        j--;
                    }
                }
            }
        }

    }
    public void CheckWin()
    {
        if (animalList.animalMatch.Count == 0)
        {
            Debug.Log("You Win");
        }
    }
}
