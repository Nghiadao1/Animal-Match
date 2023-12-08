using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : PermanentMonoBehaviourSingleton<GameState>
{
    [SerializeField] private GameModel gameModel;
    [SerializeField] private TextAsset csvLevel;
    [SerializeField] private TextAsset csvLayer;
    public LayerController layerBase;
    [SerializeField] private int level;
    [SerializeField] private List<string> fields = new List<string>();
    // private PieceItemManager PieceItemManager => PieceItemManager.Instance;
    //public GameManager GameManager => GameManager.Instance;
    void Start()
    {
        Init();
    }
    private void Init()
    {
        UpdateLevelCSV();
        LoadLayer();
        LoadLevel();
    }

    private void UpdateLevelCSV()
    {
        csvLevel = Resources.Load<TextAsset>("CSVs/Levels/Level" + level);
        csvLayer = Resources.Load<TextAsset>("CSVs/Layers/Layer1");
    }
    public void LoadLayer()
    {
        var csvReader = new CsvReader();
        var csvData = csvReader.ReadCsv(csvLayer.text);
        foreach (var line in csvData)
            foreach (var step in line)
            {
                int stepNumber = int.Parse(step);
                Debug.Log("Step {0} hear" + stepNumber);
                layerBase.IntanceGroup(stepNumber);
            }
    }
    public void LoadLevel()
    {
        var csvReader = new CsvReader();
        var csvData = csvReader.ReadCsv(csvLevel.text);
        foreach (var line in csvData)
            foreach (var field in line)
                fields.Add(field);
        SetData();
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
                    try
                    {
                        var type = (PieceType)int.Parse(fields[index]);
                        index++;
                        pieceModel.Type = type;
                    }
                    catch
                    {
                        Debug.Log("Done");
                    }
                }
            }
        }

    }
}
