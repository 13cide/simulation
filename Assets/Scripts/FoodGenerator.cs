using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{

    [SerializeField] private int secondsToFood = 5;

    private bool[,] foodMap;

    private int n;

    void Awake()
    {
        n = GameObject.FindAnyObjectByType<SimulationManager>().n;
        foodMap = new bool[n, n];
    }

    public Vector2Int GenerateFood(Vector2Int cell, int radius, bool firstGenerate = false) {
        if (firstGenerate) foodMap[cell.x, cell.y] = true;
        radius *= secondsToFood;
        List<Vector2Int> spawnPosisions = new List<Vector2Int>();
        for (int i = cell.x-radius > 0 ? cell.x-radius : 0; i < (cell.x+radius < n ? cell.x+radius : n); ++i) {
            for (int j = cell.y-radius > 0 ? cell.y+radius : 0; j < (cell.y+radius < n ? cell.y+n : n); ++j) {
                if (Math.Abs(cell.x-i) + Math.Abs(cell.y-j) <= radius && !foodMap[i, j]) {
                    spawnPosisions.Add(new Vector2Int(i,j));
                }
            }
        }
        if (spawnPosisions.Count > 0) {
            Vector2Int pos = spawnPosisions[UnityEngine.Random.Range(0, spawnPosisions.Count)];
            foodMap[pos.x, pos.y] = true;
            foodMap[cell.x, cell.y] = false;
            return pos;
        }
        else return GenerateFood(cell, radius/secondsToFood+2);
    }
}
