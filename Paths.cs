using System;
using System.Collections.Generic;
namespace Swin_Adventure
{
    public class Paths
    {
        //Fields
        private List<Path> _paths = new List<Path>();
        //Properties
        public List<Path> PathList
        {
            get
            {
                return _paths;
            }
        }
        //Methods
        public Path Fetch(String id)
        {
            foreach (Path i in _paths)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            return null;
        }
        //Add path to paths
        public void Put(Path p)
        {
            _paths.Add(p);
        }
    }
}
