using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        public enum DayOfWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(IEnumerable<T> source, DayOfWeek firstDay)
        {
            var part = new List<T>();

            foreach (var item in source)
            {
                if (item.ToString() != firstDay.ToString())
                    part.Add(item);

                if (item.ToString() == firstDay.ToString())
                {
                    yield return part;
                    part = new List<T>();
                    part.Add(item);
                }
            }

            if (part.Count > 0)
                yield return part;
        }

        static IEnumerable<DayOfWeek> GetSortedDayOfWeek(DayOfWeek firstDayOfWeek)
        {
            var parts = Split<DayOfWeek>((IEnumerable<DayOfWeek>)Enum.GetValues(typeof(DayOfWeek)), firstDayOfWeek);

            IEnumerable<DayOfWeek> result = new List<DayOfWeek>();

            foreach (var part in parts)
                if (parts.Last().Count() == part.Count())
                    result = part.Concat(parts.First());

            return result;
            //throw new NotImplementedException();
        }
        static void Main(string[] args)
        {
            var result = GetSortedDayOfWeek(DayOfWeek.Friday);
            result.ToList().ForEach(i => Console.WriteLine(i));
            Console.ReadKey();
        }
    }
}
