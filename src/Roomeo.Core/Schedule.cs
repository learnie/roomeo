using System;

namespace Roomeo.Core
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

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals(obj as Schedule);
        }

        public bool IsOverlap(Schedule schedule)
        {
            return 
                Begin < schedule.End && schedule.Begin < End;
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