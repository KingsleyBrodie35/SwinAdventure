namespace Swin_Adventure
{
    public class Path : GameObject
    {
        //Fields
        private Location _destination;
        //Properties
        public Location Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = value;
            }
        }
        //Constructor
        public Path(string[] idents, string name, string desc) : base(idents, name, desc) { }
        
    }
}
