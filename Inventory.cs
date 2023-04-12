using System;
using System.Collections.Generic;


namespace Swin_Adventure
{
    //Managed collection of items
    public class Inventory
    {
        private List<Item> _items = new List<Item>();
        public Inventory() { }
        
        //Add item to list
        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public string ItemList
        {
            get
            {
                string ItmList = "";  
                foreach(Item i in _items)
                {
                    ItmList = ItmList.Insert(0, "   " + i.ShortDescription + "\n");
                }
                return ItmList;
            }
        }
        //Remove item from list using id from IdentifiableObject
        public Item Take(String id)
        {
            Item Itm;
            foreach(Item i in _items)
            {
                if (i.AreYou(id))
                {
                    Itm = i;
                    _items.Remove(i);
                    return Itm;
                }
            }
            return null;
        }
        //Returns Item based on id
        public Item Fetch(String id)
        {
            foreach(Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            return null;
        }
        //Returns bool based on id
        public bool hasItem(string id)
        {
            foreach(Item i in _items) {
                if (i.AreYou(id)) {
                    return true;
                }
            }
            return false;
        }
    }
}
