using System;

namespace Roomeo.Reservation
{
    public class Schedule : IEquatable<Schedule>
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public Schedule(DateTime start, DateTime end)
        {
            End = end;
            Start = start;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Schedule);
        }

        public bool Equals(Schedule other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(other, this))
                return true;

            return Start == other.Start &&
                   End == other.End;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                hash = hash * 19 + Start.GetHashCode();
                hash = hash * 19 + End.GetHashCode();
                return hash;
            }
        }
    }
}