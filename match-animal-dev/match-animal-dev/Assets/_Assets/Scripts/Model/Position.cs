using System;
using UnityEngine;

[Serializable]
public struct Position
{
    [SerializeField] private Vector2Int _pos;

    public Position(int row, int column)
    {
        _pos = new Vector2Int(column, row);
    }

    public int Row => _pos.y;
    public int Column => _pos.x;

    public override string ToString()
    {
        return $"[{Row}, {Column}]";
    }
}