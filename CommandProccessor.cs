using System;
using System.Collections.Generic;

namespace Swin_Adventure
{
    public class CommandProccessor 
    {
        //Fields
        private List<Command> _commands = new List<Command>();
        //Constructor
        public CommandProccessor()
        {
            _commands.Add(new LookCommand());
            _commands.Add(new MoveCommand());
            _commands.Add(new TransferCommand());
        }
        //Methods
        public string Process(Player p, String[] cmd)
        {
            foreach (Command i in _commands)
            {
                if (i.AreYou(cmd[0]))
                {
                    return i.Execute(p, cmd);
                }
            }
            return "Cannot execute command";
        }
    }
}
