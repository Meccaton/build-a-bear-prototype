using UnityEngine;

public class CrossController : MonoBehaviour
{
    public CrossCheck crossChecker;

    // Track what the player selected: is it a row or column, and which index
    private bool? selectedIsRow = null; // null = no selection
    private int selectedIndex = -1;

    // Call this from your UI or selection logic whenever player selects a line
    public void SetSelectedLine(bool isRow, int index)
    {
        selectedIsRow = isRow;
        selectedIndex = index;
        Debug.Log($"Selected line: {(isRow ? "Row" : "Col")} {index}");
    }

    void Update()
    {
        // Wait for player to press X to cross the selected line
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (selectedIsRow.HasValue && selectedIndex >= 0)
            {
                int crossIndex = crossChecker.TryCrossLine(selectedIsRow.Value, selectedIndex);
                if (crossIndex != -1)
                {
                    Debug.Log($"Cross success! Combination index: {crossIndex}");
                    // TODO: notify game manager, remove plushes, etc
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
    }
}
