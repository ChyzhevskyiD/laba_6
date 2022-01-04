using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace laba_6666
{
    public interface InNum
    {
        public string name { get; set; }
        public string type { get; set; }
        public short number { get; set; }
        public double weight { get; set; }
    }

    class Num : InNum, IComparable<Num>
    {
        public string name { get; set; }
        public string type { get; set; }
        public short number { get; set; }
        public double weight { get; set; }
        string InNum.name { get; set; }
        string InNum.type { get; set; }
        short InNum.number { get; set; }
        double InNum.weight { get; set; }

        public Num(string name, string type, short number, double weight)
        {
            this.name = name;
            this.type = type;
            this.number = number;
            this.weight = weight;
        }

        public string Info
        {
            get { return $"{name} {type}"; }
        }

        public int CompareTo(Num other)
        {
            return string.Compare(other.Info, Info, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return String.Format("{0,20}|{1,20}|{2,20}|{3,20}", name, type, number, weight);
        }
    }

    class CollectionType<T> : IEnumerable<T> where T : Num
    {
        List<T> list = new List<T>();

        public CollectionType()
        {
            list = new List<T>();
        }

        public int Count
        {
            get { return list.Count; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return list[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                list[index] = value;
            }
        }

        public void Add(T Num)
        {
            list.Add(Num);
        }

        public T Remove(T Num)
        {
            var element = list.FirstOrDefault(h => h == Num);
            if (element != null)
            {
                list.Remove(element);
                return element;
            }
            throw new NullReferenceException();
        }

        public void Sort()
        {
            list.Sort();
        }

        public T GetByName(string name)
        {
            return
            list.FirstOrDefault(
            h => string.Compare(h.Info, name, StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class CollectionType
    {
        List<CollectionType> link = new List<CollectionType>();
        string name { get; set; }
        string type { get; set; }
        short number { get; set; }
        double weight { get; set; }

        public CollectionType() { }

        public CollectionType(string name, string type, short number, double weight)
        {
            this.name = name;
            this.type = type;
            this.number = number;
            this.weight = weight;
        }

        public void Add(CollectionType[] coll)
        {
            for (int i = 0; i < coll.Length; i++)
            {
                link.Add(coll[i]);
            }
        }

        public void Output()
        {
            Console.WriteLine(String.Format("{0,20}|{1,20}|{2,20}|{3,20}", "Найменування ", "Тип ", "Кiлькiсть ", "Вага 1 деталi(г)"));
            foreach (CollectionType s in link)
            {
                Console.WriteLine(String.Format("{0,20}|{1,20}|{2,20}|{3,20}", s.name, s.type, s.number, s.weight));
            }
        }

        public void Select()
        {
            Console.WriteLine("\n                Запит 1:");
            var where = link.Where(h => (h.number >= 80 && h.weight > 1000));
            Console.WriteLine(String.Format("{0,20}|{1,20}|{2,20}|{3,20}", "Найменування ", "Тип ", "Кiлькiсть ", "Вага 1 деталi(г)"));
            foreach (var c in where)
            {
                Console.WriteLine(String.Format("{0,20}|{1,20}|{2,20}|{3,20}", c.name, c.type, c.number, c.weight));
            }
            Console.WriteLine("\n                Запит 2:");
            var min = link.Min(h => h.weight);
            Console.WriteLine($"                {min}");
            Console.WriteLine("\n                Запит 3:");
            var max = link.Max(h => h.weight);
            Console.WriteLine($"                {max}");
            Console.WriteLine("\n                Запит 4:");
            var count = link.Count();
            Console.WriteLine($"                {count}");
            Console.WriteLine("\n                Запит 5:");
            var order = link.OrderBy(h => h.number).ThenByDescending(h => h.name);
            Console.WriteLine(String.Format("{0,20}|{1,20}|{2,20}|{3,20}", "Найменування ", "Тип ", "Кiлькiсть ", "Вага 1 деталi(г)"));
            foreach (var c in order)
            {
                Console.WriteLine(String.Format("{0,20}|{1,20}|{2,20}|{3,20}", c.name, c.type, c.number, c.weight));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Num sgn1 = new Num("Фланець", "З", 3, 450);
            Num sgn2 = new Num("Перехiдник", "К", 8, 74);
            Num sgn3 = new Num("Станина", "Про", 1, 117050);

            CollectionType<Num> collection = new CollectionType<Num>();
            collection.Add(sgn1);
            collection.Add(sgn2);
            collection.Add(sgn3);

            Console.WriteLine(String.Format("{0,20}|{1,20}|{2,20}|{3,20}", "Найменування ", "Тип ", "Кiлькiсть ", "Вага 1 деталi(г)"));
            foreach (Num s in collection)
            {
                Console.WriteLine(s.ToString());
            }

            Num sgn5 = new Num("Фланець", "З", 3, 450);
            Num sgn6 = new Num("Перехiдник", "К", 8, 74);
            Num sgn7 = new Num("Станина", "Про", 1, 117050);

            CollectionType<Num> collection2 = new CollectionType<Num>();
            collection.Add(sgn5);
            collection.Add(sgn6);
            collection.Add(sgn7);

            var list = new List<CollectionType<Num>>();
            list.Add(collection);
            list.Add(collection2);

            Console.WriteLine("\n                OrderBy:");
            var order = collection.OrderBy(h => h.number).ThenBy(h => h.name);
            foreach (var signal in order)
            {
                Console.WriteLine(signal);
            }
            Console.WriteLine("\n                where:");
            var where = collection.Where(h => (h.number >= 100 && h.weight > 1450) || h.Info.StartsWith("L"));
            foreach (var signal in where)
            {
                Console.WriteLine(signal.ToString());
            }
            Console.WriteLine("\n                Select:");
            var select = collection.Select((h, i) => new { Index = i + 1, h.Info });
            foreach (var s in select)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n                Skip:");
            var skip = collection.Skip(3);
            foreach (var signal in skip)
            {
                Console.WriteLine(signal);
            }
            Console.WriteLine("\n                Take:");
            var take = collection.Take(3);
            foreach (var signal in take)
            {
                Console.WriteLine(signal);
            }
            Console.WriteLine("\n                Concat:");
            var concat = collection.Concat(collection2);
            foreach (var signal in concat)
            {
                Console.WriteLine(signal);
            }
            Console.WriteLine("\n                First:");
            var first = collection.First(h => h.Info.Length > 5);
            Console.WriteLine(first);
            Console.Write("\n                Min: ");
            var min = collection.Min(h => h.weight);
            Console.WriteLine(min);
            Console.Write("\n                Max: ");
            var max = collection.Max(h => h.weight);
            Console.WriteLine(max);
            Console.WriteLine("\nAll and Any:");
            var allAny = list.First(c => c.All(h => h.number >= 14) && c.Any(h => h is Num)).Select(h => h.Info).OrderByDescending(s => s);
            foreach (var str in allAny)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("\nContains:");
            var contains = list.Where(c => c.Contains(sgn1)).SelectMany(c => c.SelectMany(h => h.Info.Split(' '))).Distinct().OrderBy(s => s).ToList();
            foreach (var str in contains)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();

            CollectionType ct = new CollectionType();

            CollectionType[] collections = {
                new CollectionType("Фланець", "З", 3, 450),
                new CollectionType("Перехiдник", "К", 8, 74),
                new CollectionType("Станина", "Про", 1, 117050)
            };

            ct.Add(collections);
            ct.Output();
            ct.Select();

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

