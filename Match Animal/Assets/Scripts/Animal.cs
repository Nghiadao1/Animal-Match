using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public AnimalType animalType;
    private AnimalList animalList;
    public Transform posMatch;
    private BoardMatchList boardMatchList;
    private GameManager gameManager;
    //private ListContent listContent;
    private bool isClick;
    void Start()
    {
        animalList = GameObject.Find("Board").GetComponent<AnimalList>();
        boardMatchList = GameObject.Find("Board Match").GetComponent<BoardMatchList>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //listContent = GameObject.Find("Content").GetComponent<ListContent>();
    }
    void Update()
    {
        if (isClick)
        {
            UpdatePos();
            gameManager.MatchAnimal();
            isClick = false;
            GameManager.isMatched = false;
        }
        ArrangeAnimal();
    }
    public void OnMouseDown()
    {
        Debug.Log("Animal Type: " + animalType);
        animalList.animalMatch.Add(gameObject);
        isClick = true;
    }
    public void UpdatePos()
    {
        for (int i = 0; i < boardMatchList.listPosMatch.Count; i++)
        {
            PositionMatch positionMatch = boardMatchList.listPosMatch[i].GetComponent<PositionMatch>();
            if (positionMatch.isHaveAnimal == false)
            {
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, boardMatchList.listPosMatch[i].position, 1f);
                positionMatch.animal = gameObject;
                break;
            }
        }
    }
    public void ArrangeAnimal()
    {
        //check if pos1 not have animal, move animal in pos2 to pos1 and continue with another pos
        for (int i = 0; i < boardMatchList.listPosMatch.Count; i++)
        {
            PositionMatch positionMatch = boardMatchList.listPosMatch[i].GetComponent<PositionMatch>();
            if (positionMatch.isHaveAnimal == false)
            {
                for (int j = i + 1; j < boardMatchList.listPosMatch.Count; j++)
                {
                    PositionMatch positionMatch2 = boardMatchList.listPosMatch[j].GetComponent<PositionMatch>();
                    if (positionMatch2.isHaveAnimal == true)
                    {
                        positionMatch.animal = positionMatch2.animal;
                        positionMatch2.animal = null;
                        positionMatch2.isHaveAnimal = false;
                        positionMatch.isHaveAnimal = true;
                        //update position of animal
                        positionMatch.animal.transform.position = Vector3.Lerp(positionMatch.animal.transform.position, positionMatch.transform.position, 1f);
                        break;
                    }
                }
            }
        }
    }
}
