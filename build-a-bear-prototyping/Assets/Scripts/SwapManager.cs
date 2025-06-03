using UnityEngine;

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
        // Swap Indices to chang visual pos. 
        int indexA = a.transform.GetSiblingIndex();
        int indexB = b.transform.GetSiblingIndex();
        a.transform.SetSiblingIndex(indexB);
        b.transform.SetSiblingIndex(indexA);

        // Swap data 
        Item tempItem = a.Item;
        a.Item = b.Item;
        b.Item = tempItem;

        // Swap pos. 
        Board.Instance.Tiles[a.x, a.y] = b;
        Board.Instance.Tiles[b.x, b.y] = a;

        // Swap co-ord
        int tempX = a.x;
        int tempY = a.y;
        a.x = b.x;
        a.y = b.y;
        b.x = tempX;
        b.y = tempY;

        PlushButton buttonA = a.GetComponent<PlushButton>();
        PlushButton buttonB = b.GetComponent<PlushButton>();
        if(buttonA != null && buttonB != null)
        {
            int tempRow = buttonA.row;
            int tempCol = buttonA.col;
            buttonA.row = buttonB.row;
            buttonA.col = buttonB.col;
            buttonB.row = tempRow;
            buttonB.col = tempCol;
        }

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
