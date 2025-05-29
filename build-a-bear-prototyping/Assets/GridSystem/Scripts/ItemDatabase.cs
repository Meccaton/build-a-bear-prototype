using UnityEngine;

public static class ItemDatabase
{
    public static Item[] Items { get; private set; }

    // this just goes through the items folder in resources!
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] private static void Initialize() => Items = Resources.LoadAll<Item>("Items/");

}
