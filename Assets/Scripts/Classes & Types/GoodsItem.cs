using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoodsItem
{   
    public string GoodsID = "null";
    public string GoodsName = "null";
    public int Price = 0;

    public GoodsItem(string name, int price)
    {
        this.GoodsID = _generateID();
        this.GoodsName = name;
        this.Price = price;
        
    }

    private string _generateID ()
    {
        return this.GoodsName;
    }

    // public int OwnerAmount = 0;
}
