using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : PermanentMonoBehaviourSingleton<GameState>
{
    [SerializeField] private GameModel gameModel;
    [SerializeField] private TextAsset csv;
    [SerializeField] private int level;
    [SerializeField] private List<string> fields = new List<string>();
    //public GameManager GameManager => GameManager.Instance;
    void Start()
    {
        Init();
    }
    private void Init()
    {
        UpdateLevelCSV();
        LoadLevel();
        SetData();
    }

    private void UpdateLevelCSV()
    {
        csv = Resources.Load<TextAsset>("CSVs/Levels/Level" + level);
    }

    public void LoadLevel()
    {
        var csvReader = new CsvReader();
        var csvData = csvReader.ReadCsv(csv.text);
        foreach (var line in csvData)
            foreach (var field in line)
                fields.Add(field);
    }
    public void SetData()
    {
        var index = 0;
        for (int i = 0; i < gameModel.BoardModels.Count; i++)
        {
            var piece = gameModel.BoardModels[i];
            for (int j = 0; j < piece.PieceRowModels.Count; j++)
            {
                var pieceRow = piece.PieceRowModels[j];
                for (int k = 0; k < pieceRow.PieceModels.Count; k++)
                {
                    var pieceModel = pieceRow.PieceModels[k];
                    var type = (PieceType)int.Parse(fields[index]);
                    index++;
                    pieceModel.Type = type;
                }
            }
        }

    }
}
