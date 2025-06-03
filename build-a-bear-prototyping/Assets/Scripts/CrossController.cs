using UnityEngine;

public class CrossController : MonoBehaviour
{
    public CrossCheck crossChecker;

    // Track what the player selected: is it a row or column, and which index
    private bool? selectedIsRow = null; // null = no selection
    private int selectedIndex = -1;

    // Call this from UI 
    public void SetSelectedLine(bool isRow, int index)
    {
        selectedIsRow = isRow;
        selectedIndex = index;
        Debug.Log($"Selected line: {(isRow ? "Row" : "Col")} {index}");
        HighlightSelectedLine(isRow, index);
    }

    void Update()
    {

        // Wait for player to press X to cross the selected line
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log($"SelectedIsRow has value: {selectedIsRow.HasValue}, and SelectedIndex has value: {selectedIndex}");
            if (selectedIsRow.HasValue && selectedIndex >= 0)
            {
                crossChecker.RebuildGridFromBoard();
                int crossIndex = crossChecker.TryCrossLine(selectedIsRow.Value, selectedIndex);
                if (crossIndex != -1)
                {
                    Debug.Log($"Cross success! Combination index: {crossIndex}");
                    // TODO: notify game manager, remove plushes, etc
                    crossChecker.ExecuteCrossLine(selectedIsRow.Value, selectedIndex);
                    ClearSelection();
                }
                else
                {
                    Debug.Log("Cross invalid: line must have exactly 4 plushes.");
                }
            }
            else
            {
                Debug.Log("No line selected to cross.");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearSelection();
        }
    }

    private void ClearSelection()
    {
        selectedIsRow = null;
        selectedIndex = -1;
        Debug.Log("Selection Cleared");
        RemoveHighlight();
    }

    private void HighlightSelectedLine(bool isRow, int index)
    {
        Debug.Log($"Highlighting {(isRow ? "row" : "column")} {index}");
    }

    private void RemoveHighlight()
    {
        Debug.Log("Removing highlight");
    }

    public string GetCurrentSelection()
    {
        if (selectedIsRow.HasValue && selectedIndex >= 0)
        {
            return $"{(selectedIsRow.Value ? "Row" : "Column")} {selectedIndex}";
        }
        return "None";
    }
}
