using System;

namespace Roomeo.Tests
{
    public class Schedule : IEquatable<Schedule>
    {

        public Schedule(DateTime begin, DateTime end)
        {
            if (begin > end) 
            {
                throw new ArgumentOutOfRangeException(nameof(begin));
            }

            Begin = begin;
            End = end;
        }

        public DateTime Begin { get; }
        public DateTime End { get; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals(obj as Schedule);
        }

        public bool Equals(Schedule other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                Begin.Equals(other.Begin) && 
                End.Equals(other.End);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            unchecked
            {
                int result = (Begin.GetHashCode() * 397);
                result = result ^ (End.GetHashCode() * 397);
                return result;
            }
        }
    }
}