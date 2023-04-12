using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    public interface IHaveInventory
    {
        string Name
        {
            get;
        } 
        GameObject Locate(string id);
        Item Remove(string id);
        Item Add(Item i);
    }
}
