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
        //ieceItemManager.Isblocked(this);

    }
    void Update()
    {
        PieceItemManager.Isblocked(this);
        UpdateColor();
    }

    private void UpdateColor()
    {
        if (!_canPutOn)
        {
            pieceIconImage.color = Color.grey;
            backgroundImage.color = Color.grey;
        }
        else
        {
            pieceIconImage.color = Color.white;
            backgroundImage.color = Color.white;
        }
    }

    private void Init()
    {
        //layerController = layerController của scoreview nó đang nằm trong
        LayerController = GetComponentInParent<LayerController>();
    }
    public void AddDirection()
    {
        direction = new List<Vector2Int>();
        direction.Add(Vector2Int.zero);
        direction.Add(Vector2Int.down);
        direction.Add(Vector2Int.left);
        direction.Add(-Vector2Int.one);
        for (int i = 0; i < direction.Count; i++)
        {
            // compare this step and next step
            //Bug can not instance true
            direction[i] = direction[i] * (LayerController.stepNextLayer);
        }
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
            // Destroy(gameObject, 0.35f);
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
        //PieceItemManager.Isblocked(this);
        GameManager.Pick(this);
    }
    // public void Restart()
    // {
    //     transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce).OnComplete(() =>
    //         {
    //             PieceItemManager.RemoveFromPieceBoard(this);
    //             Destroy(gameObject, 0f);
    //         });
    // }
}