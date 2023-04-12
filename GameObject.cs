using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    //Derivced from IdentifiableObject, Anything the player can interact with.
    public abstract class GameObject : IdentifiableObject
    {
        private string _description, _name;

        public GameObject(string[] idents, string name, string desc) :base(idents)
        {
            //Readonly properties, assignment at field level
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
        //Used when referring to the object
        public string ShortDescription
        {
            get
            {
                return $"{Name} ({FirstId})";
            }
        }
        //Used when examining the object
        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }
    }
}
