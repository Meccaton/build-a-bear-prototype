using UnityEngine;

public class CrossCheck : MonoBehaviour
{
    public PlushButton[,] grid;

    void Start()
    {
        BuildGrid();
    }

    public int TryCrossLine(bool isRow, int index)
    {
        if (grid == null)
        {
            Debug.LogError("Grid is not assigned.");
            return -1;
        }

        int numRows = grid.GetLength(0);
        int numCols = grid.GetLength(1);

        if (isRow && (index < 0 || index >= numRows)) return -1;
        if (!isRow && (index < 0 || index >= numCols)) return -1;

        int count = 0;

        if (isRow)
        {
            for (int col = 0; col < numCols; col++)
            {
                if (grid[index, col] != null) count++;
            }

            return count == 4 ? index : -1; 
        }
        else
        {
            for (int row = 0; row < numRows; row++)
            {
                if (grid[row, index] != null) count++;
            }

            return count == 4 ? numRows + index : -1; 
        }
    }

    // This is for while I dont have access to the grid set up 
        void BuildGrid()
    {
        PlushButton[] plushes = FindObjectsOfType<PlushButton>();


        int maxRow = 4;
        int maxCol = 4;

        foreach (var plush in plushes)
        {
            if (plush.row > maxRow) maxRow = plush.row;
            if (plush.col > maxCol) maxCol = plush.col;
        }

        grid = new PlushButton[maxRow, maxCol];

        // Populate grid
        foreach (var plush in plushes)
        {
            grid[plush.row, plush.col] = plush;
        }

        Debug.Log($"Grid built with size: {grid.GetLength(0)} rows x {grid.GetLength(1)} cols");
    }
}
