using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public Row[] rows;
    public Tile[,] Tiles { get; private set; }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);

    private void Awake()
    {
        Instance = this;
    }

    // this just starts the board randomized
    private void Start()
    {
        Tiles = new Tile[rows.Max(row => row.tiles.Length), rows.Length];

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                Tile tile = GetTile(x, y);

                tile.x = x;
                tile.y = y;

                tile.Item = ItemDatabase.Items[Random.Range(0, ItemDatabase.Items.Length)];

                Tiles[x, y] = tile;
            }
        }
    }

    private Tile GetTile(int x, int y)
    {
        return rows[y].tiles[x];
    }

    //  this just lets you pass in the tile to refresh it!!! The cross method should call this!!!
    public void ReplaceItemAt(Tile tile)
    {
        ReplaceItemAt(tile.x, tile.y);
    }

    // if you really want to get specific
    public void ReplaceItemAt(int x, int y)
    {
        if (IsInBounds(x, y))
        {
            var tile = Tiles[x, y];
            tile.Item = ItemDatabase.Items[Random.Range(0, ItemDatabase.Items.Length)];
        }
    }
    private bool IsInBounds(int x, int y)
    {
        return x >= 0 && y >= 0 && x < Width && y < Height;
    }
}
