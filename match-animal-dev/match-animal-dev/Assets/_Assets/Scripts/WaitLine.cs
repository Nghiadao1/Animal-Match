using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks.Sources;
using System;
using Object = UnityEngine.Object;
[Serializable]
public class PiecePair
{
    private const int MATCHING_NUMBER = 3;
    private const float DELAY_TIME_DESTROY_PIECE = 0f;
    private readonly List<PieceItemHandler> _pieces;
    public PiecePair(PieceType type)
    {
        _pieces = new List<PieceItemHandler>();
        Type = type;
    }
    public PiecePair(PieceType type, PieceItemHandler pieceItem) : this(type)
    {
        Add(pieceItem);
    }
    public PieceType Type { get; }
    public bool HasMatches => _pieces.Count >= MATCHING_NUMBER;
    public IEnumerable<PieceItemHandler> Pieces => _pieces;
    public void Add(PieceItemHandler pieceItem)
    {
        _pieces.Add(pieceItem);
    }
    public void Clean()
    {
        foreach (var piece in _pieces)
        {
            //remove piece from list pice item Handler
            piece.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce).OnComplete(() =>
            {
                Object.Destroy(piece.gameObject, DELAY_TIME_DESTROY_PIECE);
                WaitLine.Instance.waitPieces.Remove(piece.gameObject);
                PieceItemManager.Instance.pieceWaits.Remove(piece);
            });
        }
        _pieces.Clear();
    }
}
public class WaitLine : TemporaryMonoBehaviourSingleton<WaitLine>
{
    [SerializeField] private List<WaitPlase> line;
    [SerializeField] private bool shouldLog = true;
    [SerializeField] private List<PiecePair> _piecePairs;
    public List<GameObject> waitPieces = new List<GameObject>();
    //[SerializeField] private List<Position> _oldPosOfPiece;
    private int _waitingPieceCount;
    PieceItemManager PieceItemManager => PieceItemManager.Instance;
    public bool CanPutOn => !IsFull();

    void Start()
    {
        Init();
    }
    private void Init()
    {
        _piecePairs = new List<PiecePair>();
    }
    public void AddPiece(PieceItemHandler pieceItem)
    {
        if (IsFull()) return;
        //_oldPosOfPiece.Add(pieceItem.Model.Position);
        var type = pieceItem.Type;
        var piecePair = GetPiecePair(type);
        waitPieces.Add(pieceItem.gameObject);
        piecePair.Add(pieceItem);
        ArrangePiece();
        CheckMatches(piecePair);
        PieceItemManager.pieceWaits.Add(pieceItem);
        PieceItemManager.RemoveFromPieceBoard(pieceItem);
        GameManager.Instance.WinGame();
    }
    private void ArrangePiece()
    {
        _waitingPieceCount = 0;
        foreach (var piecePair in _piecePairs)
        {
            foreach (var piece in piecePair.Pieces)
            {
                if (_waitingPieceCount >= line.Count) return;
                line[_waitingPieceCount++]?.PutOn(piece);
            }
        }
    }
    void AddToPiecePairs(PieceItemHandler pieceItem)
    {



    }
    private void CheckMatches(PiecePair piecePair)
    {
        if (piecePair.HasMatches)
        {
            piecePair.Clean();
            Remove(piecePair);
            Log($"PiecePair {piecePair.Type} has matches");
        }
        Invoke("ArrangePiece", 0.5f);
    }
    private PiecePair GetPiecePair(PieceType type)
    {
        PiecePair result = null;
        if (HasPiecePair(type))
        {
            result = _piecePairs.Find(x => x.Type == type);
        }
        else
        {
            result = new PiecePair(type);
            _piecePairs.Add(result);
        }
        return result;
    }
    private void Remove(PiecePair piecePair)
    {
        _piecePairs.Remove(piecePair);

    }
    private bool HasPiecePair(PieceType type)
    {
        return _piecePairs.Exists(x => x.Type == type);
    }
    private bool IsFull()
    {
        return _waitingPieceCount >= line.Count;
    }
    private WaitPlase GetLastEmptyPlace()
    {
        return line[_waitingPieceCount + 1];
    }
    private void Log(string message)
    {
        if (shouldLog) print($"[{name}]: {message}");
    }
    public void Restart()
    {
        foreach (var piecePair in _piecePairs)
        {
            piecePair.Clean();
        }
        _piecePairs.Clear();
        _waitingPieceCount = 0;
    }
    public void Reverse()
    {
        // // reverse piece pairs back to piece board
        // foreach (var piecePair in _piecePairs)
        // {
        //     foreach (var piece in piecePair.Pieces)
        //     {
        //         PieceItemManager.AddToPieceBoard(piece);
        //         PieceItemManager.PieceItemHandlers.Add(piece);
        //         // revert piece to old position random
        //         piece.Model.Position = _oldPosOfPiece[Random.Range(0, _oldPosOfPiece.Count)];
        //         // remove old position

        //         _oldPosOfPiece.Remove(piece.Model.Position);
        //     }
        // }
        // _piecePairs.Clear();
        // _waitingPieceCount = 0;
    }

}
