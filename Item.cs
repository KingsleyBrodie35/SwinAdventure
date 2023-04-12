using System;

namespace Swin_Adventure
{
    public class Item : GameObject
    {
        //Fields
        private bool _canTake;
        //Properties
        public bool canTake
        {
            get
            {
                return _canTake;
            }
        }
        //Constructor
        public Item(string[] Idents, string name, string desc, bool canTake) : base(Idents, name, desc){
            _canTake = canTake;        
        }
    }
}
