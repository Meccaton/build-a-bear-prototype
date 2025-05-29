using UnityEngine;

public class CrossCheck : MonoBehaviour
{
    public Tile[,] grid;

    void Start()
    {
        grid = Board.Instance.Tiles;
    }

    public int TryCrossLine(bool isRow, int index)
    {
        if (grid == null)
        {
            Debug.LogError("Grid is not assigned.");
            return -1;
        }

        int width = grid.GetLength(0);
        int height = grid.GetLength(1);

        if (isRow && (index < 0 || index >= height)) return -1;
        if (!isRow && (index < 0 || index >= width)) return -1;

        int count = 0;

        if (isRow)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, index] != null) count++;
            }

            return count == 4 ? index : -1; 
        }
        else
        {
            for (int y = 0; y < height; y++)
            {
                if (grid[index, y] != null) count++;
            }

            return count == 4 ? width + index : -1; 
        }
    }

    public void ExecuteCrossLine(bool isRow, int index)
    {
        if (grid == null)
        {
            return;
        }

        int width = grid.GetLength(0);
        int height = grid.GetLength(1);

        if (isRow)
        {
            for (int x = 0; x < width; x++)
            {
                Board.Instance.ReplaceItemAt(x, index);
            }
            Debug.Log($"Crossed out row {index} and replaced with new tiles");
        }
        else
        {
            for (int y = 0; y < height; y++)
            {
                Board.Instance.ReplaceItemAt(index, y);
            }
            Debug.Log($"Crossed out column {index} and replaced with new tiles");
        }
    }

    // This is for while I dont have access to the grid set up 
    //    void BuildGrid()
    //{
    //    PlushButton[] plushes = FindObjectsOfType<PlushButton>();


    //    int maxRow = 4;
    //    int maxCol = 4;

    //    foreach (var plush in plushes)
    //    {
    //        if (plush.row > maxRow) maxRow = plush.row;
    //        if (plush.col > maxCol) maxCol = plush.col;
    //    }

    //    grid = new PlushButton[maxRow, maxCol];

    //    // Populate grid
    //    foreach (var plush in plushes)
    //    {
    //        grid[plush.row, plush.col] = plush;
    //    }

    //    Debug.Log($"Grid built with size: {grid.GetLength(0)} rows x {grid.GetLength(1)} cols");
    //}
}
