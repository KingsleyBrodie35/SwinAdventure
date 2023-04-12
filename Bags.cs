using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        public Bag(string[] Idents, string name, string desc) : base(Idents, name, desc, true){}
        
        //Return inventory to reference and add items to reference var
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public override string FullDescription
        {
            get
            {
                return $"You are carrying:\n{_inventory.ItemList}";
            }
        }

        //Asking if id belongs to Bag object, if return this (player) else search _inv for id
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }
        //Remove itm from inv
        public Item Remove(string id)
        {
            return Inventory.Take(id);
        }
        public Item Add(Item i)
        {
            Inventory.Put(i);
            return i;
        }
    }
}
