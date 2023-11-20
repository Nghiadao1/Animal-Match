using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public AnimalType animalType;
    public AnimalList animalList;
    public Transform posMatch;
    public BoardMatchList boardMatchList;
    public GameManager gameManager;
    private bool isClick;
    void Start()
    {
        animalList = GameObject.Find("Board").GetComponent<AnimalList>();
        boardMatchList = GameObject.Find("Board Match").GetComponent<BoardMatchList>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
    public void ArrangeAnimal(){

    }
}
