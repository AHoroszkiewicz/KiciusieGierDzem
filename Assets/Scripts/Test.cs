using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, IDataPersistence
{
    public List<ItemHandler> items;

    public void LoadData(GameData data)
    {
        items = data.items;
    }

    public void SaveData(ref GameData data)
    {

    }

}
