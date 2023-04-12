namespace Swin_Adventure
{
    //Derived from GameObject
    public class Player : GameObject, IHaveInventory
    {
        //Fields
        private Inventory _inventory;
        //Players start in the hallway
        private Location _location;
       //Constructor
        public Player(string name, string desc) : base(new string[] { "me", "inventory"}, name, desc)
        {
            _inventory = new Inventory();
            _location = new Location(new string[] { "hallway", "here" }, "hallway", "this is a long well lit hallway");
            Inventory locInv = _location.Inventory;
            locInv.Put(new Item(new string[] { "trapdoor" }, "trap door", "an old trap door covered by leafs", false));
        }
       //Properties
        //Return inventory to reference and add items to reference var
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        public override string FullDescription
        {
            get
            {
                return $"You are carrying:\n{_inventory.ItemList}";
            }
        }
        //Methods
        //Asking if id belongs to player object, if return this (player) else search _inv for id
        public GameObject Locate(string id)
        {
            if (!AreYou(id))
            {
                if (_inventory.Fetch(id) == null)
                {
                    // if true return null
                    if (_location == null)
                    { // if true return null
                        return null;
                    }
                    // if false return _location.Locate
                    return _location.Locate(id);
                }
                // if false return _inventory.Fetch
                return _inventory.Fetch(id);
            }
            return this;
            // if areYou true return this
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
