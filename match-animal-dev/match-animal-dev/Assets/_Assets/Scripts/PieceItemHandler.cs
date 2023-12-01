using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class PieceItemHandler : MonoBehaviour
{
    [SerializeField] private GameObject root;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image pieceIconImage;
    [SerializeField] private PieceModel model;
    [SerializeField] public int layerPiece;
    public bool _canPutOn;
    private bool _hasCleaned = true;

    private GameModel GameModel => GameModel.Instance;
    public PieceType Type => Model.Type;

    public PieceModel Model
    {
        get => model;
        private set => model = value;
    }

    public Position Position => Model.Position;

    private GameManager GameManager => GameManager.Instance;
    private PieceItemManager PieceItemManager => PieceItemManager.Instance;
    public bool IsEmpty => Type == PieceType.NONE || _hasCleaned;
    public List<Vector2Int> direction;
    void Start()
    {
        AddDirection();
        //ieceItemManager.Isblocked(this);

    }
    void Update()
    {
        PieceItemManager.Isblocked(this);
        if (!_canPutOn) pieceIconImage.color = Color.grey;
        else pieceIconImage.color = Color.white;

    }
    public void AddDirection()
    {
        direction = new List<Vector2Int>();
        direction.Add(Vector2Int.zero);
        direction.Add(Vector2Int.down);
        direction.Add(Vector2Int.left);
        direction.Add(-Vector2Int.one);
    }
    public void SetData(PieceModel model)
    {
        Model = model;
        UpdateUi();
    }

    public void Clear()
    {
        _hasCleaned = true;
        root.SetActive(false);
    }

    private void UpdateUi()
    {
        root.SetActive(true);
        backgroundImage.gameObject.SetActive(false);
        pieceIconImage.sprite = Model.Sprite;
    }

    public void SetPieceModel(PieceModel pieceModel)
    {
        Model = pieceModel;
        UpdateUi();
    }
    public void OnPieceIconClick()
    {
        Debug.Log($"Click piece: {Type}");
        //PieceItemManager.Isblocked(this);
        GameManager.Pick(this);

    }
}