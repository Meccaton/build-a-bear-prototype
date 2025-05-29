using UnityEngine;

// I love you scriptable object
[CreateAssetMenu(menuName = "PlushiePart")]
public class Item : ScriptableObject
{
    // not to be mistaken with score value, this just keeps track of what item it is!
    public int value;

    // picture :D
    public Sprite sprite;
}
