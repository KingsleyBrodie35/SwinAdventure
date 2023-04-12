using System.Collections.Generic;

namespace Swin_Adventure
{
    public class Location : GameObject, IHaveInventory
    {
        //Fields
        private Inventory _inventory = new Inventory();
        private Paths _paths = new Paths();
        //Constructor
        public Location(string[] idents, string name, string desc) :base(idents, name, desc) 
        {
        }
        //Properties
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public Paths Paths
        {
            get
            {
                return _paths;
            }
        }
        public override string FullDescription
        {
            get
            {
                return $"{base.FullDescription}\nIn this room you can see:\n{_inventory.ItemList}";
            }
        }
        //Methods
        public GameObject Locate(string id)
        {
            if (!AreYou(id))
            {
                if (_inventory.Fetch(id) == null)
                {
                    return _paths.Fetch(id);
                }
                return _inventory.Fetch(id);
            }
            return this;
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