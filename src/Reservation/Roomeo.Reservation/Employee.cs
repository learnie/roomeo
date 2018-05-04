namespace Roomeo.Reservation
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(string name)
            : this(0, name)
        {
        }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}