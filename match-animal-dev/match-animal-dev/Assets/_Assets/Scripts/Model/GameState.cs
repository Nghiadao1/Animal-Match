using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : PermanentMonoBehaviourSingleton<GameState>
{
    [SerializeField] private GameModel gameModel;
    [SerializeField] private TextAsset csvLevel;
    [SerializeField] private TextAsset csvLayer;
    [SerializeField] private TextAsset csvModel;
    public LayerController layerBase;
    [SerializeField] private int level;
    [SerializeField] private List<string> fieldList = new List<string>();
    [SerializeField] private List<int> models = new List<int>();
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
        LoadModel();
        LoadLevel();
    }

    private void UpdateLevelCSV()
    {
        csvLevel = Resources.Load<TextAsset>("CSVs/Levels/Level" + level);
        csvLayer = Resources.Load<TextAsset>("CSVs/Layers/Layer" + level);
        csvModel = Resources.Load<TextAsset>("CSVs/Model Piece/Model" + level);
    }
    public void LoadLayer()
    {
        var csvReader = new CsvReader();
        var csvData = csvReader.ReadCsv(csvLayer.text);
        foreach (var line in csvData)
            for (int i = 0; i < line.Count; i++)
            {
                var layer = int.Parse(line[i]);
                int stepNext;
                if (i + 1 < line.Count) stepNext = int.Parse(line[i + 1]);
                else stepNext = 0;
                Debug.Log("stepNext " + stepNext);
                layerBase.IntanceGroup(layer, stepNext, layerBase.transform);
            }
    }
    public void LoadLevel()
    {
        var csvReader = new CsvReader();
        var csvData = csvReader.ReadCsv(csvLevel.text);
        foreach (var line in csvData)
            foreach (var field in line)
                fieldList.Add(field);
        SetData();
    }
    public void LoadModel()
    {
        var csvReader = new CsvReader();
        var csvData = csvReader.ReadCsv(csvModel.text);
        foreach (var line in csvData)
        {
            var type = int.Parse(line[0]);
            Debug.Log(type);
            var quantity = int.Parse(line[1]);
            Debug.Log(quantity);
            AddModel(type, quantity);
        }
    }
    public void AddModel(int type, int quantity)
    {
        for (int i = 0; i < quantity; i++) models.Add(type);
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
                        var type = int.Parse(fieldList[index]);
                        if (type == 0) pieceModel.Type = PieceType.NONE;
                        else if (type == 1)
                        {
                            //in list model random 1 model and set type for pieceModel
                            var random = Random.Range(0, models.Count);
                            pieceModel.Type = (PieceType)models[random];
                            models.RemoveAt(random);
                        }
                        index++;
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
