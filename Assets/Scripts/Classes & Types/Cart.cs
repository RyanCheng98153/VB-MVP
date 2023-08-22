using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart
{
    public class ItemListSlot{
        public ItemListSlot (string id, int num) {
            this.itemID = id;
            this.itemNum = num;
        }

        public ItemListSlot (string id){
            this.itemID = id;
        }

        public string itemID = "";
        public int itemNum = 0;
    }

    public Cart ( string name )
    {
        this.CartName = name;
        this.CartID = _generateID();

    }

    public string _generateID()
    {
        return CartName;
    }

    public string CartID;
    public string CartName;
    public List<ItemListSlot> ItemsList; // store the ID of the Items
    public int subTotal = 0;
    //public string payment;
    //public string Delivery;
    // public string Description = "";
}
