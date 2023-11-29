using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameModel", fileName = "GameModel", order = 0)]
public class GameModel : ScriptableObjectSingleton<GameModel>
{
    [SerializeField] private List<Sprite> pieceSprites;

    [SerializeField] private int row;
    [SerializeField] private int column;

    [SerializeField] private List<PieceBoardModel> boardModels;
    [SerializeField] private List<PieceItemHandler> pieceItemHandlers;
    public List<Sprite> PieceSprites => pieceSprites;
    private List<PieceItemHandler> PieceItemHandlers => pieceItemHandlers;
    public int Row => row;

    public int Column => column;

    public List<PieceBoardModel> BoardModels
    {
        get => boardModels;
        private set => boardModels = value;
    }

    private PieceItemHandler GetPieceItemPrefab(PieceType type)
    {
        return PieceItemHandlers[(int)type];
    }

    public PieceItemHandler GetPieceItemInstance(PieceType type, Transform parent)
    {
        var pfb = GetPieceItemPrefab(type);
        var instance = Instantiate(pfb, parent);
        return instance;
    }
    public PieceBoardModel GetPieceBoardModel(int level)
    {
        return boardModels[level];
    }
}

[Serializable]
public class PieceBoardModel
{
    [SerializeField] private List<PieceRowModel> pieceRowModels;

    public List<PieceRowModel> PieceRowModels
    {
        get => pieceRowModels;
        set => pieceRowModels = value;
    }

    public PieceRowModel this[int row] => PieceRowModels[row];
    public PieceModel this[int row, int column] => this[row][column];
}

[Serializable]
public class PieceRowModel
{
    [SerializeField] private List<PieceModel> pieceModels;

    public List<PieceModel> PieceModels
    {
        get => pieceModels;
        private set => pieceModels = value;
    }

    public PieceModel this[int column] => PieceModels[column];
}