using UnityEditor.Tilemaps;
using UnityEngine;

/*
    Free-swapping of any 2 tiles. 
    */
public class SwapManager : MonoBehaviour
{
    public static SwapManager Instance;
    private PlushButton firstSelected = null;

    void Awake()
    {
        Instance = this;
    }

    public void SelectPlush(PlushButton plush)
    {
        if (firstSelected == null)
        {
            firstSelected = plush;
        }
        else if (plush != firstSelected)
        {
            SwapPlush(firstSelected, plush);
            firstSelected = null;

            // After swap, check for matches
            //MatchChecker.Instance.CheckAllMatches();
        }
        else
        {
            // Same plush clicked 2x
            firstSelected = null;
        }
    }

    void SwapPlush(PlushButton a, PlushButton b)
    {

        // Swap RectTransform anchored positions
        RectTransform rectA = a.GetComponent<RectTransform>();
        RectTransform rectB = b.GetComponent<RectTransform>();

        Vector2 temp = rectA.anchoredPosition;
        rectA.anchoredPosition = rectB.anchoredPosition;
        rectB.anchoredPosition = temp;

        Debug.Log($"Swapped positions: A({rectA.anchoredPosition}) B({rectB.anchoredPosition})");
    }
}
