namespace Prog_Lab3_Task3
{
    internal class Programm
    {
        static void Main()
        {
            Dictionary<string, int> products = new Dictionary<string, int>
            {
                ["Булка Здобна"] = 20,
                ["Хлiб Нiжинський"]=15,
                ["'Шалена бджiлка'"]=105, 
                ["Каша вiсяна 'Геркулес'"] = 45,
                ["Iкра червона лососева"] = 250
            };
            Dictionary<string, int> under100 = GetUnder100(products);
            Dictionary<string, int> below100 = GetBelow100(products);
            PrintUnder100(under100);
            PrintBelow100(below100);
        }

        static Dictionary<string, int> GetUnder100(Dictionary<string, int> dict)
        {
            return (from p in dict
                where p.Value >= 100
                select p).ToDictionary(s => s.Key, s => s.Value);;
        }
        
        static Dictionary<string, int> GetBelow100(Dictionary<string, int> dict)
        {
            return (from p in dict
                where p.Value < 100
                select p).ToDictionary(s => s.Key, s => s.Value);;
        }

        static void PrintUnder100(Dictionary<string, int> dict)
        {
            Console.WriteLine("Товари дорожчi 100 гривень:");
            foreach 
                (var p 
                 in from p in dict 
                 where p.Value>=100 
                 select p)
               Console.WriteLine(p.Key);
        }

        static void PrintBelow100(Dictionary<string, int> dict)
        {
            Console.WriteLine("Товари дешевшi 100 гривень:");
            foreach (var p 
                     in from p in dict 
                     where p.Value<100 
                     select p)
                Console.WriteLine(p.Key);
        }
        
    }
}

