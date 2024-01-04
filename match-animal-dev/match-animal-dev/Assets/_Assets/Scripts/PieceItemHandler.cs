using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.PlayerLoop;
using DG.Tweening;
public class PieceItemHandler : MonoBehaviour
{
    [SerializeField] private GameObject root;
    [SerializeField] private Image backgroundImage;
    [SerializeField] public Image pieceIconImage;
    [SerializeField] private PieceModel model;
    [SerializeField] public int layerPiece;
    public static bool check = true;
    public bool _canPutOn;
    public bool isInWaitLine;
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
    private LayerController LayerController;
    void Start()
    {
        Init();
        AddDirection();
        PieceItemManager.Isblocked(this);
        UpdateColor(this);
    }
    void Update()
    {
        //PieceItemManager.Isblocked(this);
        //UpdateColor(this);
    }

    public static void UpdateColor(PieceItemHandler piece)
    {
        if (!piece._canPutOn && !piece.isInWaitLine)
        {
            piece.pieceIconImage.color = Color.grey;
            piece.backgroundImage.color = Color.grey;
        }
        else
        {
            piece.pieceIconImage.color = Color.white;
            piece.backgroundImage.color = Color.white;
        }
    }

    private void Init()
    {
        LayerController = GetComponentInParent<LayerController>();
        isInWaitLine = false;
    }
    public void AddDirection()
    {
        direction = new List<Vector2Int>();
        direction.Add(Vector2Int.zero);
        direction.Add(Vector2Int.down);
        direction.Add(Vector2Int.left);
        direction.Add(-Vector2Int.one);
        for (int i = 0; i < direction.Count; i++)
            direction[i] = direction[i] * (LayerController.stepNextLayer);
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
        if (Type == PieceType.NONE)
        {
            PieceItemManager.RemoveFromPieceBoard(this);
            root.SetActive(false);
        }
        else root.SetActive(true);
        backgroundImage.gameObject.SetActive(true);
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
        GameManager.Pick(this);
    }

}