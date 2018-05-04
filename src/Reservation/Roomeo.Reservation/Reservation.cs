namespace Roomeo.Reservation
{
    public class Reservation
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Room Room { get; set; }
        public Schedule Schedule { get; set; }

        public Reservation(Employee employee, Room room, Schedule schedule)
            : this(0, employee, room, schedule)
        {
        }

        public Reservation(int id, Employee employee, Room room, Schedule schedule)
        {
            Id = id;
            Schedule = schedule;
            Room = room;
            Employee = employee;
        }
    }
}