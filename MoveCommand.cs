using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    class MoveCommand : Command
    {
        //Fields
        private Path _path;
        //Constructor
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" }) { }
        //Methods
        public override string Execute(Player p, string[] text)
        {
            //Sanitise first index
            if (text[0] == "move" || text[0] == "go" || text[0] == "head" || text[0] == "leave")
            {
                //Fetch path from player
                _path = FetchPath(p, text[1]);
                if (_path == null)
                {
                    return "You cannot go that direction";
                }
                //Set dest loc to player Location
                p.Location = _path.Destination;
                return $"You head {_path.FirstId}\n{_path.FullDescription}\n{p.Location.FullDescription}";
            }
            return "I don't know how to move like that, try another move command";
        }
        private Path FetchPath(Player p, string id)
        {
            try
            {
                return (Path)p.Locate(id);
            } catch
            {
                return null;
            }
        }

    }
}
