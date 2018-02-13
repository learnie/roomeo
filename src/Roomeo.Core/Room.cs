using System;

namespace Roomeo.Core
{
    public class Room
    {
        public Room(Guid id, string name, string floor)
        {
            Id = id;
            Name = name;
            Floor = floor;
            Active = true;
        }

        public Guid Id { get; }
        public bool Active { get; set; }
        public string Name { get; }
        public string Floor { get; }
    }
}
