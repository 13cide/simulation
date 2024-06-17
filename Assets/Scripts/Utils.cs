using UnityEngine;

public static class Utils {
    public static Vector3 CellToCord(Vector2Int cell, int fieldSize, float height = 0f) {
        float slope = (fieldSize-1)/2f;
        return new Vector3(cell.x - slope, height, cell.y - slope);
    }
}