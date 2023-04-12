namespace Swin_Adventure
{
    public class LookCommand : Command
    {
        private IHaveInventory _container;
        private string _id;
        public LookCommand() : base(new string[] {"look"}) { }
        //Takes in a look command, checks if valid, then finds the container for item, then finds the item, then return full description
        public override string Execute(Player p, string[] text) 
        {
            //Check if the command is correct
            if (text.Length > 5 || (text.Length < 3 && text.Length > 1))
            {
                return "I dont know how to look like that";
            }
            if (text[0] != "look")
            {
                return "Error in look input";
            }
            if (text.Length != 1 && text[1] != "at")
            {
                return "What do you want to look at?";
            }
            if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }
            //Look in player location for location
            if (text.Length == 1)
            {
              _container = p.Location;
              _id = p.Location.FirstId;  
            } else
            {
              _id = text[2];
            }
            //Get container
            if (text.Length == 3)
            {
                _container = p;
            }
            if (text.Length == 5)
            {
                _container = FetchContainer(p, text[4]);
            }
            if (_container == null)
            {
                return $"I can't find the {text[4]}";
            } else
            {
                //look for item within container
                return LookAtIn(_id, _container);
            }
        }
        private IHaveInventory FetchContainer(Player p, string containerID)
        {
            return (IHaveInventory)p.Locate(containerID);
        }
        private string LookAtIn(string itemID, IHaveInventory container)
        {
            GameObject itm = container.Locate(itemID);
            if (itm == null)
            {
                return $"I can't find the {itemID}";
            } else
            {
                return itm.FullDescription;
            }
        }
    }
}