using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ItemsManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject items;
    public List<ItemHandler> itemsList = new List<ItemHandler>();

    private void Start()
    {
        foreach (Transform item in items.transform)
        {
            itemsList.Add(item.gameObject.GetComponent<ItemHandler>());
        }
    }

    public void LoadData(GameData data)
    {

    }

    public void SaveData(ref GameData data)
    {
        PickItems();
        data.items = itemsList;
    }

    public void PickItems()
    {
        for (int i = itemsList.Count-1; i > 0; i--)
        {
            if (!itemsList[i].inBackpack)
            {
                itemsList.Remove(itemsList[i]);
            }
        }
    }
}
