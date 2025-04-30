using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfinding : MonoBehaviour
{
    private Dictionary<Vector2Int, int> gScore = new();
    private Dictionary<Vector2Int, int> fScore = new();
    private SortedList<int, Queue<Vector2Int>> sortList = new();
    private Queue<Vector2Int> backtrack;

    private GridDetector gridDetector;
    private CharacterMovement eMovement;
    private MovementDisplay eDisplay;
    private CharacterSheet eSheet;

    private static readonly Vector2Int[] directions = {
        new(0, 1), new(0, -1), new(1, 0), new(-1, 0)
    };

    private void Awake()
    {
        eMovement = GetComponent<CharacterMovement>();
        eDisplay = GetComponent<MovementDisplay>();
        eSheet = GetComponent<CharacterSheet>();
        gridDetector = GameObject.Find("LevelManager")?.GetComponent<GridDetector>();
    }

    public Dictionary<Vector2Int, int> BeginPathfinding()
    {
        gScore.Clear(); fScore.Clear(); sortList.Clear();
        Vector2Int start = eMovement.ReturnPosition();
        gScore[start] = 0;
        sortList[0] = new Queue<Vector2Int>();
        sortList[0].Enqueue(start);

        while (sortList.Count > 0)
        {
            int currentCost = sortList.Keys[0];
            Vector2Int current = sortList[currentCost].Dequeue();
            if (sortList[currentCost].Count == 0) sortList.Remove(currentCost);

            foreach (var dir in directions)
            {
                Vector2Int neighbor = current + dir;
                if (!IsWithinBounds(neighbor) || gScore.ContainsKey(neighbor)) continue;

                var tileData = gridDetector.ReturnTileData(neighbor);
                if (tileData?.Count == 0 || !tileData[0].TryGetComponent(out MovementTileScript tile) || tile.moveNumber <= 0)
                    continue;

                int totalCost = currentCost + tile.moveNumber;
                gScore[neighbor] = totalCost;

                if (!sortList.ContainsKey(totalCost)) sortList[totalCost] = new Queue<Vector2Int>();
                sortList[totalCost].Enqueue(neighbor);

                if (tileData.Count > 1 && tileData[1]?.CompareTag("Player") == true)
                {
                    fScore[neighbor] = totalCost;
                    return Backtrack(neighbor);
                }
            }
        }

        return null;
    }

    private Dictionary<Vector2Int, int> Backtrack(Vector2Int goal)
    {
        backtrack = new Queue<Vector2Int>();
        backtrack.Enqueue(goal);

        while (true)
        {
            Vector2Int current = backtrack.Peek();
            int minScore = int.MaxValue;
            Vector2Int next = current;

            foreach (var dir in directions)
            {
                Vector2Int neighbor = current + dir;
                if (fScore.ContainsKey(neighbor) || !gScore.TryGetValue(neighbor, out int score)) continue;

                if (score < minScore)
                {
                    minScore = score;
                    next = neighbor;
                }
            }

            if (minScore == int.MaxValue || minScore == 0) break;

            backtrack.Dequeue();
            backtrack.Enqueue(next);
            fScore[next] = minScore;
        }

        return fScore;
    }

    public void BeginPredictPathfinding()
    {
        int movement = eSheet.GetMovement(), range = eSheet.GetRange(), max = Mathf.Max(movement, range);
        gScore.Clear(); fScore.Clear(); sortList.Clear();

        for (int i = 0; i <= max; i++) sortList[i] = new Queue<Vector2Int>();

        Vector2Int start = eMovement.ReturnPosition();
        gScore[start] = 0;
        sortList[0].Enqueue(start);

        // Movement Range
        for (int i = 0; i < movement; i++)
        {
            while (sortList[i].Count > 0)
            {
                Vector2Int pos = sortList[i].Dequeue();
                foreach (var dir in directions)
                {
                    Vector2Int next = pos + dir;
                    if (gScore.ContainsKey(next) || !IsTileValid(next, i)) continue;

                    var tileData = gridDetector.ReturnTileData(next);
                    if (!tileData[0].TryGetComponent(out MovementTileScript tile)) continue;

                    int cost = tile.moveNumber, total = i + cost;
                    if (cost <= 0 || total > movement) continue;

                    gScore[next] = total;
                    sortList[total].Enqueue(next);
                    //print($" adding position {next} with value {total} to gscore");
                }
            }
        }

        // Attack Range
        for (int i = 0; i <= range; i++) sortList[i].Clear();
        foreach (var key in gScore.Keys) sortList[0].Enqueue(key);

        for (int i = 0; i < range; i++)
        {
            while (sortList[i].Count > 0)
            {
                Vector2Int cur = sortList[i].Dequeue();
                foreach (var dir in directions)
                {
                    Vector2Int next = cur + dir;
                    if (fScore.ContainsKey(next) || !IsAtkTileValid(next)) continue;

                    var tileData = gridDetector.ReturnTileData(next);
                    if (tileData[0].TryGetComponent(out MovementTileScript tile) && tile.moveNumber != 0)
                        fScore[next] = i + 1;

                    if (i + 1 <= range) sortList[i + 1].Enqueue(next);
                }
            }
        }

        eDisplay.DisplayPredictionTiles(gScore);
        eDisplay.DisplayAttackTIles(fScore);
    }

    private bool IsWithinBounds(Vector2Int pos)
    {
        var size = gridDetector.ReturnGridSize();
        return pos.x >= 0 && pos.y >= 0 && pos.x <= size.x && pos.y <= size.y;
    }

    private bool IsAtkTileValid(Vector2Int pos)
    {
        if (!IsWithinBounds(pos)) return false;
        var tile = gridDetector.ReturnTileData(pos);
        return tile[2] == null && tile[3] == null && (tile[1] == null || !tile[1].CompareTag("Player"));
    }

    private bool IsTileValid(Vector2Int pos, int currentCost)
    {
        if (!IsWithinBounds(pos)) return false;
        var tile = gridDetector.ReturnTileData(pos);
        if (!tile[0].TryGetComponent(out MovementTileScript mts)) return false;
        int moveCost = mts.moveNumber;

        if (moveCost <= 0 || currentCost + moveCost < 0) return false;
        return tile[2] == null && (tile[1] == null || !tile[1].CompareTag("Enemy"));
    }
}