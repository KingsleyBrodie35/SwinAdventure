namespace Swin_Adventure
{
    class TransferCommand : Command
    {
        private IHaveInventory _grabContainer;
        private IHaveInventory _putContainer;
        private Item _item;
        public TransferCommand() : base(new string[] { "pickup", "take", "put", "drop" }) { }
        public override string Execute(Player p, string[] text)
        {
            //Sanitise data
            if (text.Length == 3)
            {
                return "sorry I cannot execute that command";
            }
            if ((text[0] == "pickup" || text[0] == "take") && text.Length == 4 && text[2] != "from")
            {
                return "where do you want to grab the item from?";
            }
            //grab cmd
            if (text[0] == "pickup" || text[0] == "take")
            {
                if (text.Length == 2)
                {
                    _grabContainer = p.Location;
                }
                if (text.Length == 4)
                {
                    _grabContainer = FetchContainer(p, text[3]);
                }
                if (_grabContainer == null)
                {
                    return $"I can't find the {text[3]}";
                }
                return grab(text[1], _grabContainer);
            }
            //put cmd
            if (text[0] == "put" || text[0] == "drop")
            {
                if (_grabContainer == null)
                {
                    return "Please pickup item first";
                }
                if (text.Length == 2)
                {
                    _putContainer = p.Location;
                }
                if (text.Length == 4)
                {
                    _putContainer = FetchContainer(p, text[3]);
                }
                if (_putContainer == null)
                {
                    return $"I can't find the {text[3]}";
                }
                return put(_item, _grabContainer, _putContainer);
            }
            return "cannot execute command";
        }
        private IHaveInventory FetchContainer(Player p, string containerID)
        {
            return (IHaveInventory)p.Locate(containerID);
        }
        private string grab(string itemID, IHaveInventory container)
        {
            try
            {
                _item = (Item)container.Locate(itemID);
            } catch (System.InvalidCastException)
            {
                return "You cannot pick up that item";
            }
            if (_item == null)
            {
                return $"I can't find the {itemID}";
            }
            if (!_item.canTake)
            {
                return $"You cannot pick up {_item.FirstId}";
            }
            return $"You have grabbed the {_item.Name} from the {container.Name}";
        }
        private string put(Item i, IHaveInventory removeFrom, IHaveInventory addTo)
        {
            Item j = removeFrom.Remove(i.FirstId);
            addTo.Add(i);
            _grabContainer = null;
            return $"You have put the {i.Name} in the {addTo.Name}";
            
        }
    }
}
