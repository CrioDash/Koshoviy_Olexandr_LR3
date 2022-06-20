namespace Prog_Lab3
{
    internal class Programm
    {
        static void Main()
        {
            List<Obj> objects = new List<Obj>();
            objects.Add(new Obj{Id = 1});
            objects.Add(new Obj{Id = 2});
            objects.Add(new Obj{Id = 3});
            objects.Add(new Obj{Id = 4});
            objects.Add(new Obj{Id = 5});
            FindObj(objects, 3);
            FindObj(objects, 6);
        }

        static void FindObj(List<Obj> list, int id)
        {
            Console.WriteLine($"Об'єкт з ID:{id} - {(list.Find(x => x.Id.Equals(id)) != null ? "знайдено" : "не знайдено")}");
        }

    }

    internal class Obj
    {
        public int Id { set; get; }
    }
}