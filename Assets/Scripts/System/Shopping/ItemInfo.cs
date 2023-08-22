using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    private GoodsItem Item;

    public string ID = "null";
    public string Name = "null";
    public int Price = 0;

    // Start is called before the first frame update
    void Start()
    {
        Item.GoodsID = ID;
        Item.GoodsName = Name;
        Item.Price = Price;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
