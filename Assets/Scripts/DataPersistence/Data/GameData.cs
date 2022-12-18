using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public List<ItemHandler> items;

    public GameData()
    {
        items = new List<ItemHandler>();
    }
}
