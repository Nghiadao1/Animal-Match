using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PieceModel
{
    [SerializeField] private PieceType type;

    public PieceType Type
    {
        get => type;
        set => type = value;
    }

    public Position Position { get; set; }

    private List<Sprite> PieceSprites => GameModel.PieceSprites;
    private GameModel GameModel => GameModel.Instance;

    public Sprite Sprite => PieceSprites[(int)Type];
}