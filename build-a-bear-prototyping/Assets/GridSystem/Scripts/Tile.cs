using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int x;
    public int y;

    public Image partImage;

    private Item _item;

    // sets the item/plushie part for the tile :D
    public Item Item
    {
        get => _item;

        set
        {
            if (_item == value) return;
            _item = value;
            partImage.sprite = _item.sprite;
        }
    }

    public Button button;

    public void ReplaceItem()
    {
        if (Board.Instance != null)
        {
            Board.Instance.ReplaceItemAt(this);
        }
    }

}
