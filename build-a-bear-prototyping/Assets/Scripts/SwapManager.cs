using UnityEngine;
using UnityEngine.UI;

/*
    Free-swapping of any 2 tiles. 
    */
public class SwapManager : MonoBehaviour
{
    public static SwapManager Instance;
    private Tile firstSelected = null;

    void Awake()
    {
        Instance = this;
    }

    public void SelectPlush(Tile tile)
    {
        if (firstSelected == null)
        {
            firstSelected = tile;
            Debug.Log($"First tile selected at ({tile.x}, {tile.y})");

            //Not currently implemented
            HighlightTile(tile, true);
        }
        else if (tile != firstSelected)
        {
            Debug.Log($"Second tile selected at ({tile.x}, {tile.y}) - Swapping");
            SwapPlush(firstSelected, tile);

            //not currently implemented
            HighlightTile(firstSelected, false);
            firstSelected = null;

            // After swap, check for matches
            //MatchChecker.Instance.CheckAllMatches();
        }
        else
        {
            // Same plush clicked 2x
            Debug.Log("Same tile clicked twice, cancelling selection");
            //not currently implemented
            HighlightTile(firstSelected, false);
            firstSelected = null;
        }
    }

    void SwapPlush(Tile a, Tile b)
    {

        Debug.Log($"Attempting swap: A = {a.name} @ index {a.transform.GetSiblingIndex()}, B = {b.name} @ index {b.transform.GetSiblingIndex()}");

        Transform parentA = a.transform.parent;
        Transform parentB = b.transform.parent;

        // Swap parents if necessary (vertical swap)
        if (parentA != parentB)
        {
            // Get sibling indices 
            int indexA = a.transform.GetSiblingIndex();
            int indexB = b.transform.GetSiblingIndex();

            // Temp detach (prevent hierarchy conflicts)
            a.transform.SetParent(null);
            b.transform.SetParent(null);

            // Swap parents
            a.transform.SetParent(parentB);
            b.transform.SetParent(parentA);

            // Restore order in parent. 
            a.transform.SetSiblingIndex(indexB);
            b.transform.SetSiblingIndex(indexA);

        }
        // Row swap
        else
        {
            // Same row
            int indexA = a.transform.GetSiblingIndex();
            int indexB = b.transform.GetSiblingIndex();

            a.transform.SetSiblingIndex(indexB);
            b.transform.SetSiblingIndex(indexA);
        }
        // Force layout rebuild on both rows
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)parentA);
        if (parentA != parentB)
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)parentB);


        Debug.Log($"Swapped tiles: ({a.x},{a.y}) <-> ({b.x},{b.y})");
    }

    private void HighlightTile(Tile tile, bool highlight)
    {
        //TODO: implement tile selection highlighting
    }

    public bool IsTileSelected(Tile tile)
    {
        return firstSelected == tile;
    }

    public void ClearSelection()
    {
        if (firstSelected != null)
        {
            HighlightTile(firstSelected, false);
            firstSelected = null;
        }
    }
}
