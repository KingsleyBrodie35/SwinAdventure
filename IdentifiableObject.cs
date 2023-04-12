using System;
using System.Collections.Generic;


namespace Swin_Adventure
{
    public class IdentifiableObject
    {
        /*fields*/
        private List<string> _identifiers;
        //class constructor is a method that shares the same name as the class. Run when an instance of class is created
        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            foreach(string i in idents)
            {
                //this method is accessed within the class, so it does not need an instance to be called upon.
                AddIdentifer(i);
            }
        }
        /*properties*/
        /*returns initial index of identifer list*/
        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                return _identifiers[0];
            }
        }
        /*methods
        /*checks passed in string against each index in the array*/
        public bool AreYou(string id)
        {
            foreach(string i in _identifiers)
            {
                id = id.ToLower();
                if (_identifiers.Contains(id))
                {
                    return true;
                }
            }
            return false;
        }
        public void AddIdentifer(string id)
        {
            id = id.ToLower();
            _identifiers.Add(id);
        }
    }
}
