using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamda_Homework
{
    class Program
    {
        #region StaticFields
        private static List<int> _integers = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 9 };

        private static List<string> _strings = new List<string> {
            "Hello",
            "World!",
            "I",
            "am",
            "a",
            "list",
            "of",
            "strings",
        };

        #endregion

        #region StaticMethods
        static int Aggregate(Func<int, int, int> f, List<int> list)
        {
            int result = list[0];
            for (int i = 1; i < list.Count; ++i)
            {
                result = f(result, list[i]);
            }

            return result;
        }

        static IEnumerable<int> Select(Func<int, int> f, IEnumerable<int> list)
        {
            List<int> result = new List<int>();
            foreach (int val in list)
            {
                result.Add(f(val));
            }
            return result;
        }

        static void ForEach<T>(Action<T> f, IEnumerable<T> list)
        {
            foreach (T val in list)
            {
                f(val);
            }
        }

        static int Sum(int a, int b) => a + b;

        static int Multiply(int a, int b) => a * b;

        static int MakeDouble(int a) => 2 * a;

        static int Square(int a) => a * a;
        #endregion

        static void Main(string[] args)
        {
            // 1a
            Console.WriteLine(Aggregate(Sum, _integers));
            // 1b
            Console.WriteLine(Aggregate(Multiply, _integers));
            // 1c
            Console.WriteLine(Aggregate((x, y) => x + y, _integers));
            // 1d
            Console.WriteLine(Aggregate((x, y) => x * y, _integers));
            // 2a
            foreach (int num in Select(MakeDouble, _integers))
                Console.Write(num + " ");

            Console.WriteLine();

            // 2b
            foreach (int num in Select(Square, _integers))
                Console.Write(num + " ");

            Console.WriteLine();

            // 2c
            foreach (int num in Select(x => 2 * x, _integers))
                Console.Write(num + " ");

            Console.WriteLine();

            // 2d
            foreach (int num in Select(x => x * x, _integers))
                Console.Write(num + " ");

            Console.WriteLine();

            // 3a
            ForEach<int>((x) => Console.WriteLine(x), _integers);
            // 3b
            ForEach<string>((x) => Console.WriteLine(x), _strings);


            Console.Read();
        }
    }
}